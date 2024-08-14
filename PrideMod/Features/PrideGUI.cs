using MSCLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PrideMod.Features
{
    internal class PrideGUI
    {
        // 0 - none, 1 - gay menu, 2 - trans menu, 3 - nb menu, 4 - pan menu
        public static void Load(SettingsDropDownList dropDownList)
        {
            GameObject hud = GameObject.Find("GUI/HUD");

            TextMesh hunger = hud.transform.GetChild(3).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh thirst = hud.transform.GetChild(2).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh stress = hud.transform.GetChild(4).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh urine = hud.transform.GetChild(5).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh fatigue = hud.transform.GetChild(6).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh dirtiness = hud.transform.GetChild(7).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            TextMesh money = hud.transform.GetChild(8).Find("HUDLabel").gameObject.GetComponent<TextMesh>();

            switch (dropDownList.GetSelectedItemIndex())
            {
                case 1:
                    hunger.color = new Color32(228, 3, 3, 255);
                    thirst.color = new Color32(255, 140, 0, 255);
                    stress.color = new Color32(255, 237, 0, 255);
                    urine.color = new Color32(0, 128, 38, 255);
                    fatigue.color = new Color32(0, 77, 255, 255);
                    dirtiness.color = new Color32(117, 7, 135, 255);
                    break;
                case 2:
                    hunger.color = new Color32(1, 171, 254, 255);
                    thirst.color = new Color32(255, 171, 186, 255);
                    stress.color = new Color32(250, 250, 250, 255);
                    urine.color = new Color32(255, 171, 186, 255);
                    fatigue.color = new Color32(1, 171, 254, 255);
                    break;
                case 3:
                    hunger.color = new Color32(255, 244, 51, 255);
                    thirst.color = new Color32(255, 255, 255, 255);
                    stress.color = new Color32(155, 89, 208, 255);
                    urine.color = new Color32(45, 45, 45, 255);
                    break;
                case 4:
                    hunger.color = new Color32(255, 33, 140, 255);
                    thirst.color = new Color32(255, 33, 140, 255);
                    stress.color = new Color32(255, 216, 0, 255);
                    urine.color = new Color32(255, 216, 0, 255);
                    fatigue.color = new Color32(33, 177, 255, 255);
                    dirtiness.color = new Color32(33, 177, 255, 255);
                    break;
                case 5:
                    hunger.color = new Color32(255, 255, 255, 255);
                    thirst.color = new Color32(255, 255, 255, 255);
                    stress.color = new Color32(255, 255, 255, 255);
                    urine.color = new Color32(210, 31, 60, 255);
                    fatigue.color = new Color32(210, 31, 60, 255);
                    dirtiness.color = new Color32(210, 31, 60, 255);
                    break;
                case 6:
                    hunger.color = new Color32(215, 10, 116, 255);
                    thirst.color = new Color32(215, 10, 116, 255);
                    stress.color = new Color32(156, 84, 151, 255);
                    urine.color = new Color32(8, 62, 171, 255);
                    fatigue.color = new Color32(8, 62, 171, 255);
                    break;
                case 7:
                    hunger.color = new Color32(8, 8, 8, 255);
                    thirst.color = new Color32(164, 164, 164, 255);
                    stress.color = new Color32(238, 238, 238, 255);
                    urine.color = new Color32(118, 7, 118, 255);
                    break;
                case 8:
                    hunger.color = customPickers[0].GetValue();
                    thirst.color = customPickers[1].GetValue();
                    stress.color = customPickers[2].GetValue();
                    urine.color = customPickers[3].GetValue();
                    fatigue.color = customPickers[4].GetValue();
                    dirtiness.color = customPickers[5].GetValue();
                    money.color = customPickers[6].GetValue();
                    break;
            }
        }

        internal static SettingsColorPicker[] customPickers = new SettingsColorPicker[7];

        internal static void SetColours(SettingsColorPicker color1, SettingsColorPicker color2,
            SettingsColorPicker color3, SettingsColorPicker color4, SettingsColorPicker color5,
            SettingsColorPicker color6, SettingsColorPicker color7)
        {
            customPickers[0] = color1;
            customPickers[1] = color2;
            customPickers[2] = color3;
            customPickers[3] = color4;
            customPickers[4] = color5;
            customPickers[5] = color6;
            customPickers[6] = color7;
        }
    }
}