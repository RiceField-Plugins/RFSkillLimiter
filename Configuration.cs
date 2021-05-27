using System.Collections.Generic;
using System.Xml.Serialization;
using RFSkillLimiter.Models;
using Rocket.API;

namespace RFSkillLimiter
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string MessageColor;
        public bool UseHarmonyPatch;
        [XmlArrayItem("Skill")]
        public List<SkillLimitModel> SkillLimits;
        
        public void LoadDefaults()
        {
            Enabled = true;
            MessageColor = "magenta";
            UseHarmonyPatch = true;
            SkillLimits = new List<SkillLimitModel>
            {
                new SkillLimitModel("agriculture", 1, "skilllimit.low"),
                new SkillLimitModel("cardio", 1, "skilllimit.low"),
                new SkillLimitModel("agriculture", 2, "skilllimit.medium"),
                new SkillLimitModel("cardio", 2, "skilllimit.medium"),
            };
        }
    }
}