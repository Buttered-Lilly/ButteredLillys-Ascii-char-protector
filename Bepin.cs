using BepInEx;
using UnityEngine;


namespace Ascii_char_protector
{
    [BepInPlugin("0a26c5bd-f173-47f8-8f50-006dd6806ce6", "Ascii char protector", "1.0.0")]
    public class Bepin : BaseUnityPlugin
    {

        Ascii_char_protector_Core charPro;

        private void Awake()
        {
            if (Ascii_char_protector_Core.charProinstance != null)
                return;
            GameObject g = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
            g.hideFlags = UnityEngine.HideFlags.HideAndDontSave;
            charPro = g.AddComponent<Ascii_char_protector_Core>();
            charPro.Logger = logger;

            var harmony = new HarmonyLib.Harmony("Ascii char protector");
            harmony.PatchAll();
        }

        public bool logger(string mesg)
        {
            Logger.LogInfo($"{mesg}");
            return true;
        }
    }
}
