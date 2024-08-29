using BepInEx;
using UnityEngine;
using HarmonyLib;

namespace InfectionFixer
{
    [BepInPlugin("com.grab.gtag.tagfixer", "TagFixer", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public Harmony instance = new Harmony("com.grab.gtag.tagfixer");
        public void OnEnable()
        {
            instance.PatchAll();
        }
    }
    [HarmonyPatch(typeof(VRRig), "LateUpdate")]
    internal class InfectionFixer
    {
        private static void Postfix(VRRig __instance)
        {
            __instance.mainSkin.material = __instance.materialsToChangeTo[__instance.setMatIndex];
        }
    }
}
