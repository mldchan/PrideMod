using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PrideMod.Features.PrideFlags
{
    public class PrideFlagCreator
    {
        public void GUIFlagCreator()
        {
            int w = Screen.width;
            int h = Screen.height;
            float halfWidth = w / 2f;
            float halfHeight = h / 2f;
            switch (PrideFlagsMod.EditorData.Window)
            {
                case PrideFlagsMod.EditorCurrentWindow.List:
                    GUIFlagCreator_List(halfWidth, halfHeight);
                    break;
                case PrideFlagsMod.EditorCurrentWindow.NameNew:
                    GUIFlagCreator_NameNew(halfWidth, halfHeight);
                    break;
                case PrideFlagsMod.EditorCurrentWindow.Edit:
                    GUIFlagCreator_Edit(halfWidth, halfHeight);
                    break;
                case PrideFlagsMod.EditorCurrentWindow.ColorEdit:
                    GUIFlagCreator_ColorEdit(halfWidth, halfHeight);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GUIFlagCreator_ColorEdit(float halfWidth, float halfHeight)
        {
            CustomFlag selected = PrideFlagsMod.Custom.FirstOrDefault(x => x.Name == PrideFlagsMod.EditorData.CurrentName);
            if (selected == null)
            {
                PrideFlagsMod.EditorData.CurrentName = "";
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.List;
                return;
            }

            string txt = "";
            switch (PrideFlagsMod.EditorData.EditingColor)
            {
                case 1:
                    txt = "first";
                    break;
                case 2:
                    txt = "second";
                    break;
                case 3:
                    txt = "third";
                    break;
                case 4:
                    txt = "fourth";
                    break;
                case 5:
                    txt = "fifth";
                    break;
                case 6:
                    txt = "sixth";
                    break;
            }

            GUI.Box(new Rect(halfWidth - 100, halfHeight - 50, 200, 100), $"Edit {txt} colour");
            GUI.Label(new Rect(halfWidth - 95, halfHeight - 30, 50, 20), "Red");
            GUI.Label(new Rect(halfWidth - 95, halfHeight - 10, 50, 20), "Green");
            GUI.Label(new Rect(halfWidth - 95, halfHeight + 10, 50, 20), "Blue");

            PrideFlagsMod.EditorData.EditingColorR = GUI.HorizontalSlider(
                new Rect(halfWidth - 40, halfHeight - 30, 130, 20), PrideFlagsMod.EditorData.EditingColorR, 0f, 1f);
            PrideFlagsMod.EditorData.EditingColorG = GUI.HorizontalSlider(
                new Rect(halfWidth - 40, halfHeight - 10, 130, 20), PrideFlagsMod.EditorData.EditingColorG, 0f, 1f);
            PrideFlagsMod.EditorData.EditingColorB = GUI.HorizontalSlider(
                new Rect(halfWidth - 40, halfHeight + 10, 130, 20), PrideFlagsMod.EditorData.EditingColorB, 0f, 1f);

            Color a = GUI.contentColor;
            GUI.contentColor = new Color(PrideFlagsMod.EditorData.EditingColorR,
                PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB);
            GUI.Label(new Rect(halfWidth - 95, halfHeight + 30, 190, 20), "This is how it looks");
            GUI.contentColor = a;

            if (!GUI.Button(new Rect(halfWidth - 95, halfHeight + 50, 190, 20), "Save")) return;
            PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.Edit;
            switch (PrideFlagsMod.EditorData.EditingColor)
            {
                case 1:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB),
                        Two = selected.Colours.Two,
                        Three = selected.Colours.Three,
                        Four = selected.Colours.Four,
                        Five = selected.Colours.Five,
                        Six = selected.Colours.Six
                    };
                    break;
                case 2:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = selected.Colours.One,
                        Two = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB),
                        Three = selected.Colours.Three,
                        Four = selected.Colours.Four,
                        Five = selected.Colours.Five,
                        Six = selected.Colours.Six
                    };
                    break;
                case 3:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = selected.Colours.One,
                        Two = selected.Colours.Two,
                        Three = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB),
                        Four = selected.Colours.Four,
                        Five = selected.Colours.Five,
                        Six = selected.Colours.Six
                    };
                    break;
                case 4:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = selected.Colours.One,
                        Two = selected.Colours.Two,
                        Three = selected.Colours.Three,
                        Four = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB),
                        Five = selected.Colours.Five,
                        Six = selected.Colours.Six
                    };
                    break;
                case 5:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = selected.Colours.One,
                        Two = selected.Colours.Two,
                        Three = selected.Colours.Three,
                        Four = selected.Colours.Four,
                        Five = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB),
                        Six = selected.Colours.Six
                    };
                    break;
                case 6:
                    selected.Colours = new PrideFlag.PrideFlagColours
                    {
                        One = selected.Colours.One,
                        Two = selected.Colours.Two,
                        Three = selected.Colours.Three,
                        Four = selected.Colours.Four,
                        Five = selected.Colours.Five,
                        Six = new Color(PrideFlagsMod.EditorData.EditingColorR,
                            PrideFlagsMod.EditorData.EditingColorG, PrideFlagsMod.EditorData.EditingColorB)
                    };
                    break;
            }

            PrideFlagsMod.SaveCustomFlags();
        }

        private void GUIFlagCreator_Edit(float halfWidth, float halfHeight)
        {
            CustomFlag selected = PrideFlagsMod.Custom.FirstOrDefault(x => x.Name == PrideFlagsMod.EditorData.CurrentName);
            if (selected == null)
            {
                PrideFlagsMod.EditorData.CurrentName = "";
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.List;
                return;
            }

            int howManyColours;
            switch (selected.Preset)
            {
                case PrideFlag.PrideFlagPreset.Two:
                    howManyColours = 2;
                    break;
                case PrideFlag.PrideFlagPreset.Three:
                case PrideFlag.PrideFlagPreset.ThreeSmallMiddle:
                    howManyColours = 3;
                    break;
                case PrideFlag.PrideFlagPreset.Four:
                    howManyColours = 4;
                    break;
                case PrideFlag.PrideFlagPreset.Five:
                    howManyColours = 5;
                    break;
                case PrideFlag.PrideFlagPreset.Six:
                    howManyColours = 6;
                    break;
                case PrideFlag.PrideFlagPreset.Intersex: // Intersex is not a custom flag
                case PrideFlag.PrideFlagPreset.Queer: // Queer is not a custom flag
                default:
                    throw new ArgumentOutOfRangeException();
            }

            GUI.Box(new Rect(halfWidth - 100, halfHeight - 100, 200, 200), $"Editing {selected.Name}");
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight - 80, 190, 20), "Change first color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 1;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.One.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.One.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.One.b;
            }

            if (GUI.Button(new Rect(halfWidth - 95, halfHeight - 60, 190, 20),
                    "Change second color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 2;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.Two.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.Two.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.Two.b;
            }

            if (howManyColours >= 3 &&
                GUI.Button(new Rect(halfWidth - 95, halfHeight - 40, 190, 20), "Change third color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 3;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.Three.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.Three.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.Three.b;
            }

            if (howManyColours >= 4 && GUI.Button(new Rect(halfWidth - 95, halfHeight - 20, 190, 20),
                    "Change fourth color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 4;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.Four.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.Four.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.Four.b;
            }

            if (howManyColours >= 5 &&
                GUI.Button(new Rect(halfWidth - 95, halfHeight, 190, 20), "Change fifth color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 5;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.Five.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.Five.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.Five.b;
            }

            if (howManyColours >= 6 &&
                GUI.Button(new Rect(halfWidth - 95, halfHeight + 20, 190, 20), "Change sixth color"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.ColorEdit;
                PrideFlagsMod.EditorData.EditingColor = 6;
                PrideFlagsMod.EditorData.EditingColorR = selected.Colours.Six.r;
                PrideFlagsMod.EditorData.EditingColorG = selected.Colours.Six.g;
                PrideFlagsMod.EditorData.EditingColorB = selected.Colours.Six.b;
            }

            if (GUI.Button(new Rect(halfWidth - 95, halfHeight - 80 + howManyColours * 20, 190, 20), "< Back"))
            {
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.List;
                PrideFlagsMod.EditorData.CurrentName = "";
            }
        }

        private void GUIFlagCreator_NameNew(float halfWidth, float halfHeight)
        {
            GUI.Box(new Rect(halfWidth - 100, halfHeight - 120, 200, 240), "New Custom Flag");
            GUI.Label(new Rect(halfWidth - 95, halfHeight - 100, 190, 20), "Name of flag");

            PrideFlagsMod.EditorData.NewName =
                GUI.TextField(new Rect(halfWidth - 95, halfHeight - 80, 190, 20), PrideFlagsMod.EditorData.NewName);
            Color originalColor = GUI.contentColor;
            GUI.Label(new Rect(halfWidth - 95, halfHeight - 60, 190, 20), "Flag layout");
            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.Two)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight - 40, 190, 20), "2 stripes"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.Two;
            GUI.contentColor = originalColor;

            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.Three)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight - 20, 190, 20), "3 stripes"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.Three;
            GUI.contentColor = originalColor;

            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.ThreeSmallMiddle)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight, 190, 20), "3 stripes (middle is small)"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.ThreeSmallMiddle;
            GUI.contentColor = originalColor;

            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.Four)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight + 20, 190, 20), "4 stripes"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.Four;
            GUI.contentColor = originalColor;

            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.Five)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight + 40, 190, 20), "5 stripes"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.Five;
            GUI.contentColor = originalColor;

            if (PrideFlagsMod.EditorData.NewPreset == PrideFlag.PrideFlagPreset.Six)
                GUI.contentColor = Color.green;
            if (GUI.Button(new Rect(halfWidth - 95, halfHeight + 60, 190, 20), "6 stripes"))
                PrideFlagsMod.EditorData.NewPreset = PrideFlag.PrideFlagPreset.Six;
            GUI.contentColor = originalColor;

            GUI.Label(new Rect(halfWidth - 90, halfHeight + 80, 190, 20), "Create flag");


            CustomFlag existingFlag = PrideFlagsMod.Custom.FirstOrDefault(x => x.Name == PrideFlagsMod.EditorData.NewName);
            if (existingFlag == null && GUI.Button(new Rect(halfWidth - 95, halfHeight + 100, 190, 20), "Create"))
            {
                PrideFlagsMod.Custom.Add(new CustomFlag
                {
                    Name = PrideFlagsMod.EditorData.NewName,
                    Colours = new PrideFlag.PrideFlagColours
                    {
                        One = Color.black,
                        Two = Color.black,
                        Three = Color.black,
                        Four = Color.black,
                        Five = Color.black,
                        Six = Color.black
                    },
                    Preset = PrideFlagsMod.EditorData.NewPreset
                });
                PrideFlagsMod.SaveCustomFlags();
                PrideFlagsMod.EditorData.CurrentName = PrideFlagsMod.EditorData.NewName;
                PrideFlagsMod.EditorData.NewName = "";
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.List;
            }
            else if (existingFlag != null)
            {
                Color a = GUI.contentColor;
                GUI.contentColor = Color.red;
                GUI.Label(new Rect(halfWidth - 95, halfHeight + 100, 190, 20), "An existing flag has been found");
                GUI.contentColor = a;
            }
        }

        private void GUIFlagCreator_List(float halfWidth, float halfHeight)
        {
            GUI.Box(new Rect(halfWidth - 200, halfHeight - 300, 400, 600), "Custom Flag List");

            if (GUI.Button(new Rect(halfWidth + 150, halfHeight - 285, 20, 20), "+"))
                PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.NameNew;
            if (GUI.Button(new Rect(halfWidth + 175, halfHeight - 285, 20, 20), "x"))
                PrideFlagsMod.EditorData.Show = false;

            int i = 0;
            CustomFlag toRemove = null;

            foreach (CustomFlag customFlag in PrideFlagsMod.Custom)
            {
                GUI.Label(new Rect(halfWidth - 195, halfHeight - 260 + i, 390, 20), customFlag.Name);
                if (GUI.Button(new Rect(halfWidth - 35, halfHeight - 260 + i, 80, 20), "Spawn"))
                {
                    GameObject flag = Object.Instantiate(PrideFlagsMod.Presets[(int)customFlag.Preset]);
                    
                    flag.transform.position = PrideFlagsMod.Player.transform.position;
                    flag.name = $"{customFlag.Name} Flag (Clone)";
                    PrideFlag flagT = flag.AddComponent<PrideFlag>();

                    flagT.preset = customFlag.Preset;
                    flagT.SetColours(customFlag.Colours);
                }

                if (GUI.Button(new Rect(halfWidth + 35, halfHeight - 260 + i, 80, 20), "Edit"))
                {
                    PrideFlagsMod.EditorData.CurrentName = customFlag.Name;
                    PrideFlagsMod.EditorData.Window = PrideFlagsMod.EditorCurrentWindow.Edit;
                }

                if (GUI.Button(new Rect(halfWidth + 115, halfHeight - 260 + i, 80, 20), "Delete"))
                    toRemove = customFlag;
                i += 15;
            }

            if (toRemove != null) PrideFlagsMod.Custom.Remove(toRemove);
        }
    }
}