using RFSkillLimiter.Models;
using RFSkillLimiter.Utils;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace RFSkillLimiter.EventListeners
{
    public static class PlayerEvent
    {
        public static void OnSkillUpgraded(PlayerSkills skills, byte speciality, byte index, byte level)
        {
            var player = UnturnedPlayer.FromPlayer(skills.player);
            var skill = SkillModel.Parse(speciality, index);
            if (!SkillUtil.LimitChecks(player, skill, (byte)(level + 1), out var skillLimit))
            {
                skills.ServerSetSkillLevel(speciality, index, skillLimit.MaxLevel);
                skills.ServerSetExperience(skills.experience + skills.skills[speciality][index].cost);
                player.SendChat(Plugin.Inst.Translate("rfskillmanager_limit_reach", skillLimit.Name, skillLimit.MaxLevel), Plugin.MsgColor);
            }
        }
    }
}