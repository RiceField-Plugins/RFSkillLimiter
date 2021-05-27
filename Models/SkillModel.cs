namespace RFSkillLimiter.Models
{
    public class SkillModel
    {
        public byte Speciality;
        public byte Skill;
        
        public static readonly SkillModel Overkill = new SkillModel((byte) 0, (byte) 0);
        public static readonly SkillModel Sharpshooter = new SkillModel((byte) 0, (byte) 1);
        public static readonly SkillModel Dexterity = new SkillModel((byte) 0, (byte) 2);
        public static readonly SkillModel Cardio = new SkillModel((byte) 0, (byte) 3);
        public static readonly SkillModel Exercise = new SkillModel((byte) 0, (byte) 4);
        public static readonly SkillModel Diving = new SkillModel((byte) 0, (byte) 5);
        public static readonly SkillModel Parkour = new SkillModel((byte) 0, (byte) 6);
        public static readonly SkillModel Sneakybeaky = new SkillModel((byte) 1, (byte) 0);
        public static readonly SkillModel Vitality = new SkillModel((byte) 1, (byte) 1);
        public static readonly SkillModel Immunity = new SkillModel((byte) 1, (byte) 2);
        public static readonly SkillModel Toughness = new SkillModel((byte) 1, (byte) 3);
        public static readonly SkillModel Strength = new SkillModel((byte) 1, (byte) 4);
        public static readonly SkillModel Warmblooded = new SkillModel((byte) 1, (byte) 5);
        public static readonly SkillModel Survival = new SkillModel((byte) 1, (byte) 6);
        public static readonly SkillModel Healing = new SkillModel((byte) 2, (byte) 0);
        public static readonly SkillModel Crafting = new SkillModel((byte) 2, (byte) 1);
        public static readonly SkillModel Outdoors = new SkillModel((byte) 2, (byte) 2);
        public static readonly SkillModel Cooking = new SkillModel((byte) 2, (byte) 3);
        public static readonly SkillModel Fishing = new SkillModel((byte) 2, (byte) 4);
        public static readonly SkillModel Agriculture = new SkillModel((byte) 2, (byte) 5);
        public static readonly SkillModel Mechanic = new SkillModel((byte) 2, (byte) 6);
        public static readonly SkillModel Engineer = new SkillModel((byte) 2, (byte) 7);

        public SkillModel()
        {
            
        }
        public SkillModel(byte speciality, byte skill)
        {
          this.Speciality = speciality;
          this.Skill = skill;
        }
        
        public static SkillModel Parse(string skill)
        {
            switch (skill.ToLower())
            {
                case "overkill": return Overkill;
                case "sharpshooter": return Sharpshooter;
                case "dexterity": return Dexterity;
                case "cardio": return Cardio;
                case "exercise": return Exercise;
                case "diving": return Diving;
                case "parkour": return Parkour;
                case "sneakybeaky": return Sneakybeaky;
                case "vitality": return Vitality;
                case "immunity": return Immunity;
                case "toughness": return Toughness;
                case "strength": return Strength;
                case "warmblooded": return Warmblooded;
                case "survival": return Survival;
                case "healing": return Healing;
                case "crafting": return Crafting;
                case "outdoors": return Outdoors;
                case "cooking": return Cooking;
                case "fishing": return Fishing;
                case "agriculture": return Agriculture;
                case "mechanic": return Mechanic;
                case "engineer": return Engineer;
            }
            return null;
        }
        public static SkillModel Parse(byte speciality, byte skill)
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