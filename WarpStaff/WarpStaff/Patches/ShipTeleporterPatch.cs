using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WarpStaff.Patches
{
    [HarmonyPatch]
    internal class ShipTeleporterPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipTeleporter), "Awake")]

        private static void Awake(ShipTeleporter __instance)
        {
            if(__instance.isInverseTeleporter) 
            {
                __instance.teleporterSpinSFX = ModBase.soundFX[1];
            }
            else
            {
                __instance.beamUpPlayerBodySFX = ModBase.soundFX[0];
            }
        }


    }
}
