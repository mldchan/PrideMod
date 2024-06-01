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

        // 0 - none, 1 - gay menu, 2 - trans menu, 3 - nb menu
        public static void Load(SettingsDropDownList dropDownList)
        {
            var hud = GameObject.Find("GUI/HUD");

            var hunger = hud.transform.GetChild(2).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var thirst = hud.transform.GetChild(3).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var stress = hud.transform.GetChild(4).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var urine = hud.transform.GetChild(5).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var fatigue = hud.transform.GetChild(6).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var dirtiness = hud.transform.GetChild(7).Find("HUDLabel").gameObject.GetComponent<TextMesh>();
            var money = hud.transform.GetChild(8).Find("HUDLabel").gameObject.GetComponent<TextMesh>();

            switch (dropDownList.GetSelectedItemIndex())
            {
                case 1:
                    hunger.color = new Color(228, 3, 3);
                    thirst.color = new Color(255, 140, 0);
                    stress.color = new Color(255, 237, 0);
                    urine.color = new Color(0, 128, 38);
                    fatigue.color = new Color(0, 77, 255);
                    dirtiness.color = new Color(117, 7, 135);
                    break;
                case 2:
                    hunger.color = new Color(1, 207, 254);
                    thirst.color = new Color(255, 171, 186);
                    stress.color = new Color(250, 250, 250);
                    urine.color = new Color(255, 171, 186);
                    fatigue.color = new Color(1, 207, 254);
                    break;
                case 3:
                    hunger.color = new Color(255, 244, 51);
                    thirst.color = new Color(255, 255, 255);
                    stress.color = new Color(155, 89, 208);
                    urine.color = new Color(45, 45, 45);
                    break;
            }
        }

    }
}
