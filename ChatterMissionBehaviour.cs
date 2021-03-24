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
    public class ChatterMissionBehaviour : MissionBehaviour
    {
        //Mission currentMission;
        
        public override MissionBehaviourType BehaviourType => MissionBehaviourType.Other;
        public override void OnMissionTick(float dt)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnMissionTick()"));
            NPCChatter.ConversationEngine.runConversations();
            InformationManager.DisplayMessage(new InformationMessage("OnMissionTickEnd()"));
        }
        protected override void OnEndMission()
        {
            InformationManager.DisplayMessage(new InformationMessage("OnEndMission()"));
            ConversationEngine.clearConversations();
        }
    }
}
