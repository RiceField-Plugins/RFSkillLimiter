using HarmonyLib;
using RFSkillLimiter.EventListeners;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace RFSkillLimiter
{
    public class Plugin : RocketPlugin<Configuration>
    {
        public static Plugin Inst;
        public static Configuration Conf;
        public static Color MsgColor;
        internal static Harmony Harmony;

        protected override void Load()
        {
            Inst = this;
            Conf = Configuration.Instance;
            
            if (Conf.Enabled)
            {
                MsgColor = UnturnedChat.GetColorFromName(Conf.MessageColor, Color.green);

                if (Conf.UseHarmonyPatch)
                {
                    Harmony = new Harmony("RFSkillLimiter.Patches");
                    Harmony.PatchAll();
                }
                else
                    PlayerSkills.OnSkillUpgraded_Global += PlayerEvent.OnSkillUpgraded;
            }
            else
                Logger.LogError($"[{Name}] Plugin: DISABLED");

            Logger.LogWarning($"[{Name}] Plugin loaded successfully!");
            Logger.LogWarning($"[{Name}] RFSkillLimiter v1.0.0");
            Logger.LogWarning($"[{Name}] Made with 'rice' by RiceField Plugins!");
        }

        protected override void Unload()
        {
            if (Conf.Enabled)
            {
                if (Conf.UseHarmonyPatch)
                {
                    Harmony.UnpatchAll("RFSkillLimiter.Patches");
                }
                else
                    PlayerSkills.OnSkillUpgraded_Global -= PlayerEvent.OnSkillUpgraded;
            }
            
            Inst = null;
            Conf = null;

            Logger.LogWarning($"[{Name}] Plugin unloaded successfully!");
        }
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"rfskilllimiter_limit_reach", "[RFSkillLimiter] Skill has reached max level! [Skill] {0} [Max] {1}"},
        };
    }
}