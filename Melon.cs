using MelonLoader;
using UnityEngine;


[assembly: MelonInfo(typeof(Ascii_char_protector.MelonLoad), "Ascii char protector", "1.0.0", "Lilly", null)]
[assembly: MelonOptionalDependencies("BepInEx")]

namespace Ascii_char_protector
{
    public class MelonLoad : MelonMod
    {
        Ascii_char_protector_Core charPro;

        public override void OnInitializeMelon()
        {
            if (charPro != null)
                return;
            charPro = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube)).AddComponent<Ascii_char_protector_Core>();
            charPro.gameObject.hideFlags = HideFlags.HideAndDontSave;
            charPro.Logger = logger;
        }

        public bool logger(string mesg)
        {
            MelonLogger.Msg(mesg);
            return true;
        }
    }
}
