using System.Collections.Generic;
using System.Xml.Serialization;
using RFSkillLimiter.Enums;
using RFSkillLimiter.Models;
using Rocket.API;

namespace RFSkillLimiter
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string MessageColor;
        public string MessageIconUrl;
        public bool RevertPlayerSkillProgress;
        [XmlArrayItem("Limit")]
        public HashSet<SkillLimitPermission> Limits;
        
        public void LoadDefaults()
        {
            Enabled = true;
            MessageColor = "magenta";
            MessageIconUrl = "https://cdn.jsdelivr.net/gh/RiceField-Plugins/UnturnedImages@images/plugin/Announcer.png";
            RevertPlayerSkillProgress = false;
            Limits = new HashSet<SkillLimitPermission>
            {
                new()
                {
                    Permission = "skilllimit.min",
                    Skills = new HashSet<SkillLimit>
                    {
                        new(ESkill.CARDIO, 1),
                        new(ESkill.DIVING, 1),
                        new(ESkill.COOKING, 1),
                        new(ESkill.FISHING, 1),
                        new(ESkill.HEALING, 1),
                        new(ESkill.PARKOUR, 1),
                        new(ESkill.CRAFTING, 1),
                        new(ESkill.ENGINEER, 1),
                        new(ESkill.EXERCISE, 1),
                        new(ESkill.IMMUNITY, 1),
                        new(ESkill.MECHANIC, 1),
                        new(ESkill.OUTDOORS, 1),
                        new(ESkill.OVERKILL, 1),
                        new(ESkill.STRENGTH, 1),
                        new(ESkill.SURVIVAL, 1),
                        new(ESkill.VITALITY, 1),
                        new(ESkill.DEXTERITY, 1),
                        new(ESkill.TOUGHNESS, 1),
                        new(ESkill.AGRICULTURE, 1),
                        new(ESkill.SNEAKYBEAKY, 1),
                        new(ESkill.WARMBLOODED, 1),
                        new(ESkill.SHARPSHOOTER, 1),
                    }
                },
                new()
                {
                    Permission = "skilllimit.default",
                    Skills = new HashSet<SkillLimit>
                    {
                        new(ESkill.CARDIO, 5),
                        new(ESkill.DIVING, 5),
                        new(ESkill.COOKING, 3),
                        new(ESkill.FISHING, 5),
                        new(ESkill.HEALING, 7),
                        new(ESkill.PARKOUR, 5),
                        new(ESkill.CRAFTING, 3),
                        new(ESkill.ENGINEER, 3),
                        new(ESkill.EXERCISE, 5),
                        new(ESkill.IMMUNITY, 5),
                        new(ESkill.MECHANIC, 5),
                        new(ESkill.OUTDOORS, 5),
                        new(ESkill.OVERKILL, 7),
                        new(ESkill.STRENGTH, 5),
                        new(ESkill.SURVIVAL, 5),
                        new(ESkill.VITALITY, 5),
                        new(ESkill.DEXTERITY, 5),
                        new(ESkill.TOUGHNESS, 5),
                        new(ESkill.AGRICULTURE, 7),
                        new(ESkill.SNEAKYBEAKY, 7),
                        new(ESkill.WARMBLOODED, 5),
                        new(ESkill.SHARPSHOOTER, 7),
                    }
                },
            };
        }
    }
}