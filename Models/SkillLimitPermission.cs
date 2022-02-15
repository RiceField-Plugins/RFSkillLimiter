using System.Collections.Generic;
using System.Xml.Serialization;

namespace RFSkillLimiter.Models
{
    public class SkillLimitPermission
    {
        [XmlAttribute]
        public string Permission { get; set; }
        [XmlArrayItem("Value")]
        public HashSet<SkillLimit> Skills { get; set; }

        public SkillLimitPermission()
        {
            
        }

        public override bool Equals(object obj)
        {
            if (obj is not SkillLimitPermission skillLimitPermission)
                return false;

            return skillLimitPermission.Permission == Permission;
        }

        public override int GetHashCode()
        {
            return Permission.GetHashCode();
        }
    }
}