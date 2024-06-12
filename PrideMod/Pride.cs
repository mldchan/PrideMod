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

        public override string Version => "0.1";

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
                "Default", "LGBTQ", "Transgender", "NonBinary", "Pansexual"
            }, 1);
        }

        private void OnLoad()
        {
            PrideGUI.Load(PrideGUISelection);
        }
    }
}
