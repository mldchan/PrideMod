using MSCLoader;
using UnityEngine;
using UnityEngine.UI;

namespace PrideMod.Features.MSCOwOify
{
    public class MscOwOify
    {
        internal static SettingsCheckBox smileys, stutter, yu, reidentifier, owoifier;
        internal static SettingsDropDownList identity;
        
        private static float _timer;
        
        internal static void ReapplyUwuification()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<UwUifierScript>()) item.Reapply();
        }

        internal static void ApplyUwuification()
        {
            _timer += Time.deltaTime;
            if (_timer <= 30) return;
            _timer = 0;
            foreach (var item in Resources.FindObjectsOfTypeAll<TextMesh>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<GUIText>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<Text>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }
        }


        internal static void ApplyUwuificationImmediate()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<TextMesh>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<GUIText>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<Text>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }
        }
    }
}