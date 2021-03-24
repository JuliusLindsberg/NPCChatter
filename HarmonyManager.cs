using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TaleWorlds.Library;

namespace NPCChatter
{
    //this class is a copy from https://github.com/schplorg/bannersample-mod
    //as it is not in active use anymore by the project I'll probably end up removing it
    /*
    public class HarmonyManager
    {
        private static Harmony harmony = new Harmony("com.npcchatter");

        public static Exception Catch(Exception __exception)
        {
            HarmonyManager.Log(__exception.Message + " " + __exception.StackTrace);
            return null;
        }

        public static void Rethrow(Exception __exception)
        {
            HarmonyManager.Log(__exception.Message + " " + __exception.StackTrace);
            throw __exception;
        }

        public static void Finalize(string tOriginal, string mOriginal, string tFinalizer, string mFinalizer)
        {
            Type to = AccessTools.TypeByName(tOriginal);
            Type tp = AccessTools.TypeByName(tFinalizer);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mFinalizer);
            if (o == null)
            {
                Log(to + "." + mOriginal + " null!");
                return;
            }
            if (p == null)
            {
                Log(tp + "." + mFinalizer + " null!");
                return;
            }
            harmony.Patch(o, null, null, null, new HarmonyMethod(p));
        }
        public static void Prefix(string tOriginal, string mOriginal, string tPrefix, string mPrefix)
        {
            Type to = AccessTools.TypeByName(tOriginal);
            Type tp = AccessTools.TypeByName(tPrefix);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mPrefix);

            if (o == null)
            {
                Log(to + "." + mOriginal + " null!");
                return;
            }
            if (p == null)
            {
                Log(tp + "." + mPrefix + " null!");
                return;
            }
            harmony.Patch(o, new HarmonyMethod(p));
        }
        public static void Prefix(string tParent, string tOriginal, string mOriginal, string tPrefix, string mPrefix)
        {
            Type parent = AccessTools.TypeByName(tParent);
            Type to = AccessTools.Inner(parent, tOriginal);
            Type tp = AccessTools.TypeByName(tPrefix);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mPrefix);

            if (o == null)
            {
                Log(to + "." + mOriginal + " null!");
                return;
            }
            if (p == null)
            {
                Log(tp + "." + mPrefix + " null!");
                return;
            }
            harmony.Patch(o, new HarmonyMethod(p));
        }
        public static void Log(string s)
        {
            Debug.Print(s, 0, Debug.DebugColor.White, 17592186044416UL);
        }

    }
    */
}