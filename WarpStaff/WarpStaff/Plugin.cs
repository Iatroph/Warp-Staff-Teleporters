using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using WarpStaff.Patches;

namespace WarpStaff
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ModBase : BaseUnityPlugin
    {
        private const string modGUID = "Iatroph.WarpStaffTeleporters";
        private const string modName = "Warp Staff Teleporters";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ModBase Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> soundFX;
        internal static AssetBundle Bundle;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Loading WarpStaff.wav");
            mls = Logger;

            soundFX = new List<AudioClip>();
            string folderLoc = Instance.Info.Location;
            folderLoc = folderLoc.TrimEnd("WarpStaff.dll".ToCharArray());
            mls.LogInfo(folderLoc);
            Bundle = AssetBundle.LoadFromFile(folderLoc + "teleporters");

            if(Bundle != null )
            {
                mls.LogInfo("Successfully loaded asset bundle");
                soundFX = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to load asset bundle");
            }

            harmony.PatchAll();

            mls.LogInfo("WarpStaff loaded, remember to just use it");

            mls.LogInfo(soundFX[0].name);
            mls.LogInfo(soundFX[1].name);

        }
    }
}
