using BepInEx;
using MonoMod.RuntimeDetour;
using System;

namespace GiantFuckingRobot
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class RobotPlugin : BaseUnityPlugin
    {
        public const string modGUID = "grug.lethalcompany.giantrobot";
        public const string modName = "Giant Robot";
        public const string modVersion = "09.04.2996";
        public static Hook? grabbableObjectHook 
        public void Awake()
        {

        }
    }
}
