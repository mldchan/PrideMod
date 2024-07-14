using Harmony;
using JetBrains.Annotations;
using PrideMod.Features.MSCOwOify;
using UnityEngine;

namespace PrideMod.Patches.MSCOwOify
{
    [HarmonyPatch(typeof(GUIContent))]
    [HarmonyPatch("Temp")]
    [HarmonyPatch(new[] { typeof(string) })]
    public class GUIContentTemp
    {
        [HarmonyPrefix]
        [UsedImplicitly]
        static void Prefix(ref string t)
        {
            t = Identity.ConvertIdentityInSentence(t);
            t = Uwuifier.Uwuify(t, UwUifierScript.Flags);
        }
    }
}