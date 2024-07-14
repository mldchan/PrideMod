using MSCLoader;
using PrideMod.Features;
using PrideMod.Features.MSCOwOify;
using UnityEngine;

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

            SetupFunction(Setup.OnLoad, Mod_OnLoad);
            SetupFunction(Setup.OnMenuLoad, Mod_OnMenuLoad);
            SetupFunction(Setup.Update, Mod_OnUpdate);
        }

        public override void ModSettings()
        {
            base.ModSettings();

            #region Pride Stats

            Settings.AddHeader(this, "Pride Stats", collapsedByDefault: true);

            PrideGUISelection = Settings.AddDropDownList(this, "PrideGUI", "Pride GUI type", new string[]
            {
                "Default", "LGBTQ", "Transgender", "NonBinary", "Pansexual", "Polish", "Custom"
            }, 1);

            var color1 = Settings.AddColorPickerRGB(this, "PrideGUI1", "First Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color2 = Settings.AddColorPickerRGB(this, "PrideGUI2", "Second Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color3 = Settings.AddColorPickerRGB(this, "PrideGUI3", "Third Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color4 = Settings.AddColorPickerRGB(this, "PrideGUI4", "Fourth Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color5 = Settings.AddColorPickerRGB(this, "PrideGUI5", "Fifth Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color6 = Settings.AddColorPickerRGB(this, "PrideGUI6", "Sixth Color",
                defaultColor: new Color32(245, 249, 15, 255));
            var color7 = Settings.AddColorPickerRGB(this, "PrideGUI7", "Seventh Color",
                defaultColor: new Color32(245, 249, 15, 255));

            PrideGUI.SetColours(color1, color2, color3, color4, color5, color6, color7);

            #endregion

            #region MSC OwOify

            Settings.AddHeader(this, "OwOifier", collapsedByDefault: true);

            MscOwOify.owoifier =
                Settings.AddCheckBox(this, "uwuifier", "Enable uwuifier", true, MscOwOify.ReapplyUwuification);
            MscOwOify.smileys =
                Settings.AddCheckBox(this, "Smileys", "smileys (˘ᵕ˘)", true, MscOwOify.ReapplyUwuification);
            MscOwOify.stutter =
                Settings.AddCheckBox(this, "Stutter", "s- stuttering", true, MscOwOify.ReapplyUwuification);
            MscOwOify.yu = Settings.AddCheckBox(this, "Yu", "Yu", true, MscOwOify.ReapplyUwuification);

            #endregion

            #region Reidentifier

            Settings.AddHeader(this, "Reidentifier", collapsedByDefault: true);
            Settings.AddText(this,
                "The reidentifier allows you to change your identity in the game. Instead of a man or boy you can be a girl.");
            MscOwOify.reidentifier = Settings.AddCheckBox(this, "reidentifier", "Enable reidentifier", true,
                MscOwOify.ReapplyUwuification);
            MscOwOify.identity = Settings.AddDropDownList(this, "identity", "Idenitity", Identity.Identities);

            #endregion
        }

        private void Mod_OnLoad()
        {
            PrideGUI.Load(PrideGUISelection);
            MscOwOify.ApplyUwuificationImmediate();
        }

        private void Mod_OnUpdate()
        {
            MscOwOify.ApplyUwuification();
        }

        private void Mod_OnMenuLoad()
        {
            MscOwOify.ApplyUwuificationImmediate();
        }
    }
}