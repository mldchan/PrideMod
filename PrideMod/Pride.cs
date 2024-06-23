using MSCLoader;
using PrideMod.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrideMod
{
    public class Pride : Mod
    {
        public override string ID => "PrideMod";

        public override string Version => "0.2";

        public override string Author => "アカツキ";

        private SettingsDropDownList PrideGUISelection;


        public override void ModSetup()
        {
            base.ModSetup();

            SetupFunction(Setup.OnLoad, OnLoad);
        }

        public override void ModSettings()
        {
            base.ModSettings();

            PrideGUISelection = Settings.AddDropDownList(this, "PrideGUI", "Pride GUI type", new string[]
            {
                "Default", "LGBTQ", "Transgender", "NonBinary", "Pansexual", "Polish", "Custom"
            }, 1);

            var color1 = Settings.AddColorPickerRGB(this, "PrideGUI1", "First Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color2 = Settings.AddColorPickerRGB(this, "PrideGUI2", "Second Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color3 = Settings.AddColorPickerRGB(this, "PrideGUI3", "Third Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color4 = Settings.AddColorPickerRGB(this, "PrideGUI4", "Fourth Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color5 = Settings.AddColorPickerRGB(this, "PrideGUI5", "Fifth Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color6 = Settings.AddColorPickerRGB(this, "PrideGUI6", "Sixth Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));
            var color7 = Settings.AddColorPickerRGB(this, "PrideGUI7", "Seventh Color", defaultColor: new UnityEngine.Color32(245, 249, 15, 255));

            PrideGUI.SetColours(color1, color2, color3, color4, color5, color6, color7);
        }

        private void OnLoad()
        {
            PrideGUI.Load(PrideGUISelection);
        }
    }
}
