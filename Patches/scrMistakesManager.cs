using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace ADOAccuracy.Patches
{
    [HarmonyPatch(typeof(scrMistakesManager), "AddHit")]
    static class scrMistakesManager_AddHit_Patch
    {
        static bool Prefix(scrMistakesManager __instance, HitMargin hit)
        {
            Main.statsMenu.hitDict[hit] += 1;
            Main.statsMenu.currAcc = __instance.percentAcc;
            return true;
        }
    }

    [HarmonyPatch(typeof(scrController), "Restart")]
    static class scrController_Restart_Patch
    {
        static bool Prefix(scrController __instance)
        {
            Main.statsMenu.hitDict = new Dictionary<HitMargin, int>()
            {
                { HitMargin.EarlyPerfect, 0 },
                { HitMargin.TooEarly, 0 },
                { HitMargin.VeryEarly, 0 },
                { HitMargin.Perfect, 0 },
                { HitMargin.TooLate, 0 },
                { HitMargin.VeryLate, 0 },
                { HitMargin.LatePerfect, 0 },
            };
            return true;
        }
    }

    [HarmonyPatch(typeof(scrController), "Hit")]
    static class scrController_Hit_Patch
    {
        static void Postfix(scrController __instance)
        {
            if (__instance.mistakesManager != null)
            {
                Main.statsMenu.currPerc = __instance.controller.percentComplete * 100f;
            }
        }
    }
}
