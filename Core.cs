using UnityEngine;
using HarmonyLib;
using System.Text.RegularExpressions;


namespace Ascii_char_protector
{
    public class Ascii_char_protector_Core : MonoBehaviour
    {
        static public Ascii_char_protector_Core charProinstance;

        public Func<string, bool> Logger;

        public Regex filter = new Regex("[^ -~]");

        public void Start()
        {
            charProinstance = this;
        }


        [HarmonyPatch(typeof(ChatBehaviour), "New_ChatMessage")]
        public static class ServerSidePro
        {
            private static void Prefix(ref string _message)
            {
                try
                {
                    charProinstance.Logger("newchat");
                    _message = charProinstance.filter.Replace(_message, "");
                }
                catch (Exception e)
                {
                    charProinstance.Logger(e.Message);
                }
            }
        }

        [HarmonyPatch(typeof(ChatBehaviour), "Rpc_RecieveChatMessage")]
        public static class LocalPro
        {
            private static void Prefix(ref string message)
            {
                try
                {
                    charProinstance.Logger("clientrpc");
                    message = charProinstance.filter.Replace(message, "");
                }
                catch (Exception e)
                {
                    charProinstance.Logger(e.Message);
                }
            }
        }

        [HarmonyPatch(typeof(ChatBehaviour), "Cmd_SendChatMessage")]
        public static class LocalPro2
        {
            private static void Prefix(ref string _message)
            {
                try
                {
                    charProinstance.Logger("CMD");
                    _message = charProinstance.filter.Replace(_message, "");
                }
                catch (Exception e)
                {
                    charProinstance.Logger(e.Message);
                }
            }
        }

        [HarmonyPatch(typeof(ProfileDataSender), "OnRecieve_PlayerProfileData")]
        public static class LocalPro3
        {
            private static void Prefix(ref PlayerProfileDataMessage _message)
            {
                try
                {
                    charProinstance.Logger("name");
                    _message._nickName = charProinstance.filter.Replace(_message._nickName, "");
                }
                catch (Exception e)
                {
                    charProinstance.Logger(e.Message);
                }
            }
        }
    }
}