using HarmonyLib;
using RFSkillLimiter.Enums;
using RFSkillLimiter.Utils;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace RFSkillLimiter
{
    public class Plugin : RocketPlugin<Configuration>
    {
        private static int Major = 1;
        private static int Minor = 0;
        private static int Patch = 0;

        public static Plugin Inst;
        public static Configuration Conf;
        public static Color MsgColor;
        private Harmony _harmony;

        protected override void Load()
        {
            Inst = this;
            Conf = Configuration.Instance;

            if (Conf.Enabled)
            {
                MsgColor = UnturnedChat.GetColorFromName(Conf.MessageColor, Color.green);

                _harmony = new Harmony("RFSkillLimiter.Patches");
                _harmony.PatchAll();

                if (Conf.RevertPlayerSkillProgress)
                {
                    SkillUtil.RevertPlayersSkill();
                    
                    U.Events.OnPlayerConnected += OnPlayerJoined;
                }
            }
            else
                Logger.LogError($"[{Name}] Plugin: DISABLED");

            Logger.LogWarning($"[{Name}] Plugin loaded successfully!");
            Logger.LogWarning($"[{Name}] {Name} v{Major}.{Minor}.{Patch}");
            Logger.LogWarning($"[{Name}] Made with 'rice' by RiceField Plugins!");
        }

        protected override void Unload()
        {
            if (Conf.Enabled)
            {
                if (Conf.RevertPlayerSkillProgress)
                {
                    U.Events.OnPlayerConnected -= OnPlayerJoined;
                }
                
                _harmony.UnpatchAll(_harmony.Id);
            }

            Inst = null;
            Conf = null;

            Logger.LogWarning($"[{Name}] Plugin unloaded successfully!");
        }

        public override TranslationList DefaultTranslations => new()
        {
            {$"{EResponse.MAX_SKILL_REACH}", "Your {0} skill has reached max level allowed!"},
        };

        private static void OnPlayerJoined(UnturnedPlayer player)
        {
            SkillUtil.RevertPlayerSkill(player);
        }
    }
}