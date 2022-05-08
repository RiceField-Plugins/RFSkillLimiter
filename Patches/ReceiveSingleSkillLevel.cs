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
    [HarmonyPatch("ReceiveSingleSkillLevel")]
    internal static class ReceiveSingleSkillLevel
    {
        internal static bool Prefix(PlayerSkills __instance, byte speciality, byte index, byte level)
        {
            var player = UnturnedPlayer.FromPlayer(__instance.player);
            var skill = UnturnedSkill.Parse(speciality, index);
            var allow = SkillUtil.CheckSkillLimit(player, skill, level);
            if (!allow)
            {
                ChatHelper.Say(player,
                    Plugin.Inst.Translate(EResponse.MAX_SKILL_REACH.ToString(), 
                        SkillUtil.GetESkill(speciality, index)),
                    Plugin.MsgColor, Plugin.Conf.MessageIconUrl);
            }

            return allow;
        }
    }
}