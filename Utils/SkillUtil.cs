using System;
using System.Collections.Generic;
using System.Linq;
using RFSkillLimiter.Enums;
using RFSkillLimiter.Models;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace RFSkillLimiter.Utils
{
    internal static class SkillUtil
    {
        internal static byte GetMaxLevel(UnturnedSkill unturnedSkill)
        {
            if (unturnedSkill == UnturnedSkill.Overkill) return 7;
            if (unturnedSkill == UnturnedSkill.Sharpshooter) return 7;
            if (unturnedSkill == UnturnedSkill.Dexterity) return 5;
            if (unturnedSkill == UnturnedSkill.Cardio) return 5;
            if (unturnedSkill == UnturnedSkill.Exercise) return 5;
            if (unturnedSkill == UnturnedSkill.Diving) return 5;
            if (unturnedSkill == UnturnedSkill.Parkour) return 5;
            if (unturnedSkill == UnturnedSkill.Sneakybeaky) return 7;
            if (unturnedSkill == UnturnedSkill.Vitality) return 5;
            if (unturnedSkill == UnturnedSkill.Immunity) return 5;
            if (unturnedSkill == UnturnedSkill.Toughness) return 5;
            if (unturnedSkill == UnturnedSkill.Strength) return 5;
            if (unturnedSkill == UnturnedSkill.Warmblooded) return 5;
            if (unturnedSkill == UnturnedSkill.Survival) return 5;
            if (unturnedSkill == UnturnedSkill.Healing) return 7;
            if (unturnedSkill == UnturnedSkill.Crafting) return 3;
            if (unturnedSkill == UnturnedSkill.Outdoors) return 5;
            if (unturnedSkill == UnturnedSkill.Cooking) return 3;
            if (unturnedSkill == UnturnedSkill.Fishing) return 5;
            if (unturnedSkill == UnturnedSkill.Agriculture) return 7;
            if (unturnedSkill == UnturnedSkill.Mechanic) return 5;
            if (unturnedSkill == UnturnedSkill.Engineer) return 3;
            return 0;
        }

        internal static bool CheckSkillLimit(UnturnedPlayer player, UnturnedSkill unturnedSkill, byte level)
        {
            if (unturnedSkill == null)
            {
                return true;
            }

            return !IsLimitReach(player, unturnedSkill, level);
        }

        private static bool IsLimitReach(UnturnedPlayer player, UnturnedSkill unturnedSkill, byte level)
        {
            foreach (var limitPermission in Plugin.Conf.Limits)
            {
                if (player.HasPermission(limitPermission.Permission))
                {
                    var eSkill = GetESkill(unturnedSkill.Speciality, unturnedSkill.Skill);
                    if (limitPermission.Skills.Contains(new SkillLimit(eSkill, 0)))
                    {
                        limitPermission.Skills.TryGetValue(new SkillLimit(eSkill, 0), out var skillLimit);
                        if (level > skillLimit.Max)
                        {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        internal static ESkill GetESkill(byte speciality, byte skill)
        {
            switch (speciality)
            {
                case 0:
                    switch (skill)
                    {
                        case 0: return ESkill.OVERKILL;
                        case 1: return ESkill.SHARPSHOOTER;
                        case 2: return ESkill.DEXTERITY;
                        case 3: return ESkill.CARDIO;
                        case 4: return ESkill.EXERCISE;
                        case 5: return ESkill.DIVING;
                        case 6: return ESkill.PARKOUR;
                    }

                    break;
                case 1:
                    switch (skill)
                    {
                        case 0: return ESkill.SNEAKYBEAKY;
                        case 1: return ESkill.VITALITY;
                        case 2: return ESkill.IMMUNITY;
                        case 3: return ESkill.TOUGHNESS;
                        case 4: return ESkill.STRENGTH;
                        case 5: return ESkill.WARMBLOODED;
                        case 6: return ESkill.SURVIVAL;
                    }

                    break;
                case 2:
                    switch (skill)
                    {
                        case 0: return ESkill.HEALING;
                        case 1: return ESkill.CRAFTING;
                        case 2: return ESkill.OUTDOORS;
                        case 3: return ESkill.COOKING;
                        case 4: return ESkill.FISHING;
                        case 5: return ESkill.AGRICULTURE;
                        case 6: return ESkill.MECHANIC;
                        case 7: return ESkill.ENGINEER;
                    }

                    break;
            }

            throw new ArgumentOutOfRangeException();
        }

        internal static void RevertPlayersSkill()
        {
            foreach (var steamPlayer in Provider.clients)
            {
                var uPlayer = UnturnedPlayer.FromSteamPlayer(steamPlayer);
                RevertPlayerSkill(uPlayer);
            }
        }

        internal static void RevertPlayerSkill(UnturnedPlayer player)
        {
            foreach (var limitPermission in Plugin.Conf.Limits)
            {
                if (player.HasPermission(limitPermission.Permission))
                {
                    foreach (var skillLimit in limitPermission.Skills)
                    {
                        var uSkill = UnturnedSkill.Parse(skillLimit.Skill);
                        if (player.Player.skills.skills[uSkill.Speciality][uSkill.Skill].level > skillLimit.Max)
                        {
                            player.Player.skills.ServerSetSkillLevel(uSkill.Speciality, uSkill.Skill, skillLimit.Max);
                        }
                    }
                }
            }
        }
    }
}