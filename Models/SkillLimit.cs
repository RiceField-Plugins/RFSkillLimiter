using System.Collections.Generic;
using System.Xml.Serialization;
using RFSkillLimiter.Enums;

namespace RFSkillLimiter.Models
{
    public class SkillLimit
    {
        [XmlAttribute]
        public ESkill Skill { get; set; }
        [XmlAttribute]
        public byte Max { get; set; }

        public SkillLimit()
        {
            
        }

        public SkillLimit(ESkill skill, byte max)
        {
            Skill = skill;
            Max = max;
        }

        public override bool Equals(object obj)
        {
            if (obj is not SkillLimit skillLimit)
                return false;

            return skillLimit.Skill == Skill;
        }

        public override int GetHashCode()
        {
            return Skill.GetHashCode();
        }
    }
}