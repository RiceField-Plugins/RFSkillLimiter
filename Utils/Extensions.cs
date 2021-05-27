using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace RFSkillLimiter.Utils
{
    public static class Extensions
    {
        public static bool CheckPermission(this UnturnedPlayer player, string permission)
        {
            return player.HasPermission(permission) || player.IsAdminOrAsterisk();
        }
        public static bool IsAdminOrAsterisk(this UnturnedPlayer player)
        {
            return player.HasPermission("*") || player.IsAdmin;
        }
        
        public static void SendChat(this UnturnedPlayer player, string text, Color color, string iconURL = null)
        {
            ChatManager.serverSendMessage(text, color, null, player.SteamPlayer(), EChatMode.SAY, iconURL, true);
        }
        public static void SendChat(this IRocketPlayer player, string text, Color color, string iconURL = null)
        {
            ChatManager.serverSendMessage(text, color, null, PlayerTool.getSteamPlayer(new CSteamID(ulong.Parse(player.Id))), EChatMode.SAY, iconURL, true);
        }
    }
}