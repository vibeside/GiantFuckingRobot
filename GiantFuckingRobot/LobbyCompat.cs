using LobbyCompatibility.Enums;
using LobbyCompatibility.Features;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GiantFuckingRobot
{
    internal static class LobbyCompat
    {
        public static bool Enabled { get { return BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("BMX.LobbyCompatibility"); } }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void Init()
        {
            PluginHelper.RegisterPlugin(RobotPlugin.modGUID, System.Version.Parse(RobotPlugin.modVersion), CompatibilityLevel.Everyone, VersionStrictness.None);
        }
    }
}
