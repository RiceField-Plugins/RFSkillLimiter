using System;
using RFSkillLimiter.Enums;

namespace RFSkillLimiter.Models
{
    public class UnturnedSkill
    {
        public byte Speciality;
        public byte Skill;
        
        public static readonly UnturnedSkill Overkill = new(0, 0);
        public static readonly UnturnedSkill Sharpshooter = new(0, 1);
        public static readonly UnturnedSkill Dexterity = new(0, 2);
        public static readonly UnturnedSkill Cardio = new(0, 3);
        public static readonly UnturnedSkill Exercise = new(0, 4);
        public static readonly UnturnedSkill Diving = new(0, 5);
        public static readonly UnturnedSkill Parkour = new(0, 6);
        public static readonly UnturnedSkill Sneakybeaky = new(1, 0);
        public static readonly UnturnedSkill Vitality = new(1, 1);
        public static readonly UnturnedSkill Immunity = new(1, 2);
        public static readonly UnturnedSkill Toughness = new(1, 3);
        public static readonly UnturnedSkill Strength = new(1, 4);
        public static readonly UnturnedSkill Warmblooded = new(1, 5);
        public static readonly UnturnedSkill Survival = new(1, 6);
        public static readonly UnturnedSkill Healing = new(2, 0);
        public static readonly UnturnedSkill Crafting = new(2, 1);
        public static readonly UnturnedSkill Outdoors = new(2, 2);
        public static readonly UnturnedSkill Cooking = new(2, 3);
        public static readonly UnturnedSkill Fishing = new(2, 4);
        public static readonly UnturnedSkill Agriculture = new(2, 5);
        public static readonly UnturnedSkill Mechanic = new(2, 6);
        public static readonly UnturnedSkill Engineer = new(2, 7);

        public UnturnedSkill()
        {
            
        }
        
        public UnturnedSkill(byte speciality, byte skill)
        {
          Speciality = speciality;
          Skill = skill;
        }
        
        public static UnturnedSkill Parse(ESkill skill)
        {
            switch (skill)
            {
                case ESkill.OVERKILL: return Overkill;
                case ESkill.SHARPSHOOTER: return Sharpshooter;
                case ESkill.DEXTERITY: return Dexterity;
                case ESkill.CARDIO: return Cardio;
                case ESkill.EXERCISE: return Exercise;
                case ESkill.DIVING: return Diving;
                case ESkill.PARKOUR: return Parkour;
                case ESkill.SNEAKYBEAKY: return Sneakybeaky;
                case ESkill.VITALITY: return Vitality;
                case ESkill.IMMUNITY: return Immunity;
                case ESkill.TOUGHNESS: return Toughness;
                case ESkill.STRENGTH: return Strength;
                case ESkill.WARMBLOODED: return Warmblooded;
                case ESkill.SURVIVAL: return Survival;
                case ESkill.HEALING: return Healing;
                case ESkill.CRAFTING: return Crafting;
                case ESkill.OUTDOORS: return Outdoors;
                case ESkill.COOKING: return Cooking;
                case ESkill.FISHING: return Fishing;
                case ESkill.AGRICULTURE: return Agriculture;
                case ESkill.MECHANIC: return Mechanic;
                case ESkill.ENGINEER: return Engineer;
            }
            return null;
        }
        
        public static UnturnedSkill Parse(string skill)
        {
            var flag = Enum.TryParse<ESkill>(skill, true, out var eSkill);
            if (!flag)
                return null;
                
            return Parse(eSkill);
        }
        
        public static UnturnedSkill Parse(byte speciality, byte skill)
        {
            switch (speciality)
            {
                case 0:
                    switch (skill)
                    {
                        case 0: return Overkill;
                        case 1: return Sharpshooter;
                        case 2: return Dexterity;
                        case 3: return Cardio;
                        case 4: return Exercise;
                        case 5: return Diving;
                        case 6: return Parkour;
                    }
                    break;
                case 1:
                    switch (skill)
                    {
                        case 0: return Sneakybeaky;
                        case 1: return Vitality;
                        case 2: return Immunity;
                        case 3: return Toughness;
                        case 4: return Strength;
                        case 5: return Warmblooded;
                        case 6: return Survival;
                    }
                    break;
                case 2:
                    switch (skill)
                    {
                        case 0: return Healing;
                        case 1: return Crafting;
                        case 2: return Outdoors;
                        case 3: return Cooking;
                        case 4: return Fishing;
                        case 5: return Agriculture;
                        case 6: return Mechanic;
                        case 7: return Engineer;
                    }
                    break;
            }
            return null;
        }
    }
}