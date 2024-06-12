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
            var hud = GameObject.Find("GUI/HUD");

            var hunger = hud.transform.GetChild(3).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var thirst = hud.transform.GetChild(2).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var stress = hud.transform.GetChild(4).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var urine = hud.transform.GetChild(5).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var fatigue = hud.transform.GetChild(6).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var dirtiness = hud.transform.GetChild(7).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var money = hud.transform.GetChild(8).Find("HUDLabel").gameObject.GetComponent<TextMesh>();

            switch (dropDownList.GetSelectedItemIndex())
            {
                case 1:
                    hunger.color = new Color(0.894f, 0.0117f, 0.0117f);
                    thirst.color = new Color(1f, 0.549f, 0);
                    stress.color = new Color(1f, 0.9294f, 0);
                    urine.color = new Color(0, 0.5019f, 0.1490f);
                    fatigue.color = new Color(0, 0.3019f, 1f);
                    dirtiness.color = new Color(0.4588f, 0.0274f, 0.5294f);
                    break;
                case 2:
                    hunger.color = new Color(0.0039f, 0.6705f, 0.9960f);
                    thirst.color = new Color(1f, 0.6705f, 0.7294f);
                    stress.color = new Color(0.9803f, 0.9803f, 0.9803f);
                    urine.color = new Color(1f, 0.6705f, 0.7294f);
                    fatigue.color = new Color(0.0039f, 0.6705f, 0.9960f);
                    break;
                case 3:
                    hunger.color = new Color(1f, 0.9568f, 0.2f);
                    thirst.color = new Color(1f, 1f, 1f);
                    stress.color = new Color(0.6078f, 0.3490f, 0.8156f);
                    urine.color = new Color(0.1764f, 0.1764f, 0.1764f);
                    break;
                case 4:
                    hunger.color = new Color(1, 0x21 / 255f, 0x8C / 255f);
                    thirst.color = new Color(1, 0x21 / 255f, 0x8C / 255f);
                    stress.color = new Color(1, 0xD8 / 255f, 0);
                    urine.color = new Color(1, 0xD8 / 255f, 0);
                    fatigue.color = new Color(0x21 / 255f, 0xB1 / 255f, 1);
                    dirtiness.color = new Color(0x21 / 255f, 0xB1 / 255f, 1);
                    break;
            }
        }

    }
}
