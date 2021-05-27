using HarmonyLib;
using RFSkillLimiter.Models;
using RFSkillLimiter.Utils;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace RFSkillLimiter.Patches
{
    [HarmonyPatch(typeof(PlayerSkills))]
    [HarmonyPatch("ReceiveUpgradeRequest")]
    public class ReceiveUpgradeRequest
    {
        internal static bool Prefix(PlayerSkills __instance, byte speciality, byte index, bool force)
        {
            var player = UnturnedPlayer.FromPlayer(__instance.player);
            var skill = SkillModel.Parse(speciality, index);
            var uSkill = __instance.skills[speciality][index];
            if (!SkillUtil.LimitChecks(player, skill, (byte)(uSkill.level + 1), out var skillLimit))
            {
                player.SendChat(Plugin.Inst.Translate("rfskillmanager_limit_reach", skillLimit.Name, skillLimit.MaxLevel), Plugin.MsgColor);
                return false;
            }

            return true;
        }
    }
}