using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NPCChatter
{
    //these static classes should be replaced once TW implements the modding system properly
    public static class ConversationEngine
    {
        public static Random random = new Random();
        private static List<Conversation> conversations = new List<Conversation>();
        public static void noteConversation(List<Agent> members)
        {
            //this is an ugly one. It is used to note that a conversation is still ongoing or then a new one will be created
            foreach (Conversation convo in conversations)
            {
                foreach (Agent person in convo.participants)
                {
                    foreach (Agent dude in members)
                    {
                        if(dude.Index == person.Index)
                        {
                            convo.markAsOngoing();
                            return;
                        }
                    }
                }
            }
            conversations.Add(new Conversation(members));
        }
        //this function should only run once per game tick
        public static void runConversations()
        {
            //InformationManager.DisplayMessage(new InformationMessage("runConversations() Begin"));
            for (int i = conversations.Count-1; i >= 0; i--)
            {
                if (!conversations[i].isUninterrupted() || conversations[i].isCompleted())
                {
                    //a conversation does not exist anymore and therefore will be ended/removed
                    conversations.RemoveAt(i);
                }
                else
                {
                    conversations[i].run();
                }
            }
            //InformationManager.DisplayMessage(new InformationMessage("runConversations() End"));
        }
        public static void clearConversations()
        {
            conversations.Clear();
        }
    }
}
