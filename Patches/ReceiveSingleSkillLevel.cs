using HarmonyLib;
using RFSkillLimiter.Models;
using RFSkillLimiter.Utils;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace RFSkillLimiter.Patches
{
    [HarmonyPatch(typeof(PlayerSkills))]
    [HarmonyPatch("ReceiveSingleSkillLevel")]
    internal class ReceiveSingleSkillLevel
    {
        internal static bool Prefix(PlayerSkills __instance, byte speciality, byte index, byte level)
        {
            var player = UnturnedPlayer.FromPlayer(__instance.player);
            var skill = SkillModel.Parse(speciality, index);
            if (!SkillUtil.LimitChecks(player, skill, level, out var skillLimit))
            {
                player.SendChat(Plugin.Inst.Translate("rfskillmanager_limit_reach", skillLimit.Name, skillLimit.MaxLevel), Plugin.MsgColor);
                return false;
            }

            return true;
        }
    }
}