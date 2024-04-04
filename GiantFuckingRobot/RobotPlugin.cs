using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LobbyCompatibility.Features;
using LobbyCompatibility.Enums;
using MonoMod.RuntimeDetour;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace GiantFuckingRobot
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class RobotPlugin : BaseUnityPlugin
    {
        public const string modGUID = "grug.lethalcompany.giantrobot";
        public const string modName = "Giant Robot";
        public const string modVersion = "09.04.2996";
        public static ManualLogSource mls = null!;
        public static Hook? grabbableObjectHook;
        public void Awake()
        {
            if (LobbyCompat.Enabled) LobbyCompat.Init();
            mls = base.Logger;
            grabbableObjectHook = new(typeof(StormyWeather).GetMethod(nameof(StormyWeather.LightningStrike),AccessTools.allDeclared),StormyWeatherPatch);
        }
        public static void StormyWeatherPatch(Action<StormyWeather, Vector3, bool> orig, StormyWeather self,Vector3 pos, bool atobj)
        {
            orig(self,pos,atobj);
            if (atobj)
            {
                if (self.targetingMetalObject != null && self.targetingMetalObject.itemProperties.name == "RobotToy")
                {
                    RoundManager.Instance.SpawnEnemyOnServer(self.targetingMetalObject.transform.position,self.transform.eulerAngles.y);
                }
            }
        }
    }
}
