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
    [HarmonyPatch("ReceiveUpgradeRequest")]
    internal static class ReceiveUpgradeRequest
    {
        internal static bool Prefix(PlayerSkills __instance, byte speciality, byte index, bool force)
        {
            var player = UnturnedPlayer.FromPlayer(__instance.player);
            var skill = UnturnedSkill.Parse(speciality, index);
            var uSkill = __instance.skills[speciality][index];
            bool allow;
            if (force)
            {
                var level = uSkill.level;
                var exp = __instance.experience;
                while (exp >= __instance.cost(speciality, index) && uSkill.level < uSkill.GetClampedMaxUnlockableLevel())
                {
                    exp -= __instance.cost(speciality, index);
                    level += 1;
                }
                allow = SkillUtil.CheckSkillLimit(player, skill, level);
                if (!allow)
                {
                    ChatHelper.Say(player,
                        Plugin.Inst.Translate(EResponse.MAX_SKILL_REACH.ToString(), 
                            SkillUtil.GetESkill(speciality, index)),
                        Plugin.MsgColor, Plugin.Conf.MessageIconUrl);
                }
            }
            else
            {
                allow = SkillUtil.CheckSkillLimit(player, skill, (byte)(uSkill.level + 1));
                if (!allow)
                {
                    ChatHelper.Say(player,
                        Plugin.Inst.Translate(EResponse.MAX_SKILL_REACH.ToString(), 
                            SkillUtil.GetESkill(speciality, index)),
                        Plugin.MsgColor, Plugin.Conf.MessageIconUrl);
                }
            }

            return allow;
        }
    }
}