using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NPCChatter
{
    public class NPCChatterSubModule : MBSubModuleBase
    {
        static Harmony harmony;
        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);
            //HarmonyManager.Log("NPCChatter OnCampaignStart()");
            InformationManager.DisplayMessage(new InformationMessage("NPCChatter OnCampaignStart()"));
        }
        public override void OnGameLoaded(Game game, object initializerObject)
        {
            /*
            Campaign campaign = game.GameType as Campaign;
            if (campaign != null)
            {
                SandBoxManager sandBoxManager = campaign.SandBoxManager;
                //sandBoxManager.SandBoxMissionManager = new SandBoxMissionManager();
                //sandBoxManager.AgentBehaviorManager = new AgentBehaviorManager();
                //sandBoxManager.ModuleManager = new ModuleManager();
                CampaignGameStarter gameInitializer = (CampaignGameStarter)initializerObject;
                this.AddBehaviors(gameInitializer);
            }
            */
        }
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if(game.GameType is Campaign)
            {
                //add the mission behaviour here to replace the OnApplicationTick()?
            }
        }
        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);
            //HarmonyManager.Log("NPCChatter OnGameEnd()");
        }
        protected override void OnSubModuleLoad()
        {
            //what does this do?
            base.OnSubModuleLoad();
            //HarmonyManager.Prefix("Sandbox.Source.Objects.SettlementObjects.AnimationPoint", "OnUserConversationStart", "NPCChatter.Conversation", "BeginConversation");
            //HarmonyManager.Prefix("Sandbox.Source.Objects.SettlementObjects.AnimationPoint", "AnimationPoint", "NPCChatter.Conversation", "PairTick");
            harmony = new Harmony(base.GetType().Namespace);
            harmony.PatchAll();
            //InformationManager.DisplayMessage(new InformationMessage("NPCChatter loaded!"));
        }
        private void AddBehaviors(CampaignGameStarter gameInitializer)
        {
            //gameInitializer.AddBehavior(new CommonTownsfolkCampaignBehavior());
        }
        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            InformationManager.DisplayMessage(new InformationMessage("Mission start"));
            //Mission.Current.AddMissionBehaviour(new ChatterMissionBehaviour());
        }
        //so ugly
        protected override void OnApplicationTick(float dt)
        {
            ConversationEngine.runConversations();
        }
        
    }
}
