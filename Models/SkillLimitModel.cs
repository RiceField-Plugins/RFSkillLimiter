using System.Xml.Serialization;

namespace RFSkillLimiter.Models
{
    public class SkillLimitModel
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public int MaxLevel;
        [XmlAttribute]
        public string BypassPermission;

        public SkillLimitModel()
        {
            
        }

        public SkillLimitModel(string name, int maxLevel, string bypassPermission)
        {
            Name = name;
            MaxLevel = maxLevel;
            BypassPermission = bypassPermission;
        }
    }
}