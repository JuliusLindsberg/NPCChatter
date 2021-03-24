using System;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using SandBox.Source.Objects.SettlementObjects;
using TaleWorlds.MountAndBlade;
using SandBox;

namespace NPCChatter
{
    //this class contains all the Harmony patches for AnimationPoint's member functions
    [HarmonyPatch(typeof(WalkingBehavior), "ConversationTick")]
    public class ConversationTick
    {
        public static bool Prefix(ref WalkingBehavior __instance)
        {
            //InformationManager__instance.CheckTime.ToString("N3");
            /*//this function handle works
            AnimationPoint animation = __instance;
            if(animation.PairEntity)*/
            return true;
        }
    }


    [HarmonyPatch(typeof(AnimationPoint), "Tick")]
    public class Tick
    {
        public static bool Prefix(ref AnimationPoint __instance)
        {
            /*//this function handle works
            AnimationPoint animation = __instance;
            if(animation.PairEntity)*/
            return true;
        }
    }
    [HarmonyPatch(typeof(AnimationPoint), "PairTick")]
    public class PairTick
    {
        public static bool Prefix(ref AnimationPoint __instance)
        {
            /*//this function handle works
            AnimationPoint animation = __instance;
            if(animation.PairEntity)*/
            
            return true;
        }
    }
    [HarmonyPatch(typeof(AnimationPoint), "GetPairEntityUsers")]
    public class GetPairEntityUsers
    {
        public static void Postfix(ref List<Agent> __result, AnimationPoint __instance)
        {
            if (__result == null)
            {
                InformationManager.DisplayMessage(new InformationMessage("__result was null"));
                return;
            }
            //there's a conversation going on
            int i = 0;
            foreach (Agent dude in __result)
            {
                i += 1;
                //InformationManager.DisplayMessage(new InformationMessage(dude.Index.ToString() + " " + dude.Name + " is number " + i.ToString()));
            }
            if (i != 0)
            {
                i += 1;
                Agent dude = __instance.UserAgent;
                List<Agent> participants = __result;
                participants.Add(dude);
                //InformationManager.DisplayMessage(new InformationMessage(dude.Index.ToString() + " as main use agent " + dude.Name + " is number " + i.ToString()));
                ConversationEngine.noteConversation(participants);
            }
        }
    }
    [HarmonyPatch(typeof(AnimationPoint), "OnUse")]
    public class OnUse
    {
        public static void Prefix()
        {
            //InformationManager.DisplayMessage(new InformationMessage("OnUse"));
        }
    }
    //these two are called when the player ends or starts a conversations
    [HarmonyPatch(typeof(AnimationPoint), "OnUserConversationEnd")]
    public class PlayerEndsConversation
    {
        public static void Prefix()
        {
            InformationManager.DisplayMessage(new InformationMessage("a conversation has ended"));
        }
    }
    [HarmonyPatch(typeof(AnimationPoint), "OnUserConversationStart")]
    public class PlayerStartsConversation
    {
        public static void Prefix()
        {
            InformationManager.DisplayMessage(new InformationMessage("a conversation has started"));
        }
    }
}
