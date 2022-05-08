using HarmonyLib;
using RFRocketLibrary.Helpers;
using RFSkillLimiter.Enums;
using RFSkillLimiter.Models;
using RFSkillLimiter.Utils;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace RFSkillLimiter.Patches
{
    [HarmonyPatch(typeof(PlayerSkills))]
    [HarmonyPatch("ReceiveMultipleSkillLevels")]
    internal static class ReceiveMultiSkillLevel
    {
        internal static bool Prefix(PlayerSkills __instance, in ClientInvocationContext context)
        {
            return false;
        }
    }
}