using System.Collections.Generic;
using System.Linq;
using RFSkillLimiter.Models;
using Rocket.Unturned.Player;

namespace RFSkillLimiter.Utils
{
    public static class SkillUtil
    {
        public static byte GetMaxLevel(SkillModel skill)
        {
            if (skill == SkillModel.Overkill) return 7;
            if (skill == SkillModel.Sharpshooter) return 7;
            if (skill == SkillModel.Dexterity) return 5;
            if (skill == SkillModel.Cardio) return 5;
            if (skill == SkillModel.Exercise) return 5;
            if (skill == SkillModel.Diving) return 5;
            if (skill == SkillModel.Parkour) return 5;
            if (skill == SkillModel.Sneakybeaky) return 7;
            if (skill == SkillModel.Vitality) return 5;
            if (skill == SkillModel.Immunity) return 5;
            if (skill == SkillModel.Toughness) return 5;
            if (skill == SkillModel.Strength) return 5;
            if (skill == SkillModel.Warmblooded) return 5;
            if (skill == SkillModel.Survival) return 5;
            if (skill == SkillModel.Healing) return 7;
            if (skill == SkillModel.Crafting) return 3;
            if (skill == SkillModel.Outdoors) return 5;
            if (skill == SkillModel.Cooking) return 3;
            if (skill == SkillModel.Fishing) return 5;
            if (skill == SkillModel.Agriculture) return 7;
            if (skill == SkillModel.Mechanic) return 5;
            if (skill == SkillModel.Engineer) return 3;
            return 0;
        }

        public static bool LimitChecks(UnturnedPlayer player, SkillModel skill, byte level, out SkillLimitModel skillLimit)
        {
            skillLimit = null;
            if (skill == null)
            {
                return true;
            }
            if (LimitCheck(player, skill, level, out skillLimit))
            {
                return true;
            }

            return false;
        }
        public static bool LimitCheck(UnturnedPlayer player, SkillModel skillModel, byte level, out SkillLimitModel skillLimit)
        {
            var skillLimits = new List<SkillLimitModel>();
            foreach (var limit in Plugin.Conf.SkillLimits)
            {
                var skill = SkillModel.Parse(limit.Name);
                if (skillModel == skill && !player.CheckPermission(limit.BypassPermission))
                {
                    skillLimits.Add(limit);
                }
            }
            skillLimits = skillLimits.OrderBy(s => s.MaxLevel).ToList();
            foreach (var limit in skillLimits)
            {
                if (level > limit.MaxLevel)
                {
                    skillLimit = limit;
                    return false;
                }
            }
            
            skillLimit = null;
            return true;
        }
    }
}