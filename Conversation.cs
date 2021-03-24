using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.GauntletUI;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Menu.Overlay;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Menu.TownManagement;
using TaleWorlds.MountAndBlade.View.Missions;

namespace NPCChatter
{
    public class Conversation
    {
        public List<Agent> participants;
        bool uninterrupted;
        bool completed;
        int conversationLevel;
        private RandomTimer timeUntilNextSentence;
        public Conversation(List<Agent> members, bool startImmediately = false)
        {
            conversationLevel = 0;
            participants = members;
            uninterrupted = true;
            completed = false;
            //null timer means a conversation has not began. This could be handy for example if a player is too far away to witness it.
            if (startImmediately)
            {
                startConversation();
            }
            else
            {
                timeUntilNextSentence = null;
            }
        }
        Tuple<Agent, string> getNextStatement()
        {
            return new Tuple<Agent, string>(participants[ConversationEngine.random.Next(participants.Count)], "I am saying something ");

        }
        void makeStatement()
        {
            var statement = getNextStatement();
            if (statement.Item1 == null)
            {
                //change of topic
                InformationManager.DisplayMessage(new InformationMessage("topic empty"));
            }
            else
            {
                conversationLevel += 1;
                //InformationManager.DisplayMessage(new InformationMessage(statement.Item1.Name + ": " + statement.Item2 + "(level "+ conversationLevel +")"));
                InformationManager.AddQuickInformation(new TextObject( statement.Item2 +"(level" + conversationLevel + ")"), 0, statement.Item1.Character, "");
                //UIResourceManager.WidgetFactory.GetWidgetTypes();
                
            }
        }
        public bool isUninterrupted()
        {
            return uninterrupted;
        }
        public bool isCompleted()
        {
            return completed;
        }
        public void markAsOngoing()
        {
            uninterrupted = true;
        }
        public void run()
        {
            uninterrupted = false;
            if (timeUntilNextSentence == null)
            {
                if(participants[0].Position.Distance(Mission.Current.MainAgent.Position) < 30.0f)
                {
                    startConversation();
                }
                return;
            }
            if(Mission.Current == null)
            {
                return;
            }
            if (timeUntilNextSentence.Check(Mission.Current.Time))
            {
                if (ConversationEngine.random.Next(15) +1 - conversationLevel < 0)
                {
                    completed = true;
                }
                else
                {
                    makeStatement();
                    timeUntilNextSentence = new RandomTimer(Mission.Current.Time, 5.0f, 10.0f);
                }
            }
        }
        public void startConversation()
        {
            timeUntilNextSentence = new RandomTimer(Mission.Current.Time, 5.0f, 10.0f);
            timeUntilNextSentence.ChangeDuration(5.0f, 15.0f);
            InformationManager.DisplayMessage(new InformationMessage("startConversation()", new Color(0.0f, 1.0f, 0.0f)));

        }
    }
}
