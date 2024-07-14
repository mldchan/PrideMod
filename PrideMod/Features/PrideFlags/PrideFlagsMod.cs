using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using MSCLoader;
using UnityEngine;

namespace PrideMod.Features.PrideFlags
{
    public class PrideFlagsMod
    {
        internal static bool LoadedCustom;
        internal static PrideFlagCreator PrideFlagCreator = new PrideFlagCreator();

        internal static readonly List<GameObject> Presets = new List<GameObject>();
        internal static List<CustomFlag> Custom = new List<CustomFlag>();
        internal static PrideFlagsEditorData EditorData = new PrideFlagsEditorData
        {
            NewName = "",
            NewPreset = PrideFlag.PrideFlagPreset.Two,
            CurrentName = "",
            EditingColor = 0,
            EditingColorB = 1,
            EditingColorG = 1,
            EditingColorR = 1,
            Show = false,
            Window = EditorCurrentWindow.List
        };

        public static Transform Player;
        
        internal enum EditorCurrentWindow
        {
            ColorEdit,
            List,
            Edit,
            NameNew
        }

        internal struct PrideFlagsEditorData
        {
            internal EditorCurrentWindow Window;
            internal string CurrentName;
            internal string NewName;
            internal PrideFlag.PrideFlagPreset NewPreset;
            internal bool Show;
            internal int EditingColor;
            internal float EditingColorR;
            internal float EditingColorG;
            internal float EditingColorB;
        }
        
        public static void SaveCustomFlags()
        {
            var ser = new XmlSerializer(typeof(List<CustomFlag>));
            var path = Path.Combine(Application.persistentDataPath, "CustomPrideFlags.xml");
            if (File.Exists(path))
                File.Delete(path);

            using (var str = File.OpenWrite(path))
            {
                ser.Serialize(str, Custom);
            }
        }

        internal static void LoadCustomFlags()
        {
            var ser = new XmlSerializer(typeof(List<CustomFlag>));
            var path = Path.Combine(Application.persistentDataPath, "CustomPrideFlags.xml");
            if (!File.Exists(path)) return;

            using (var str = File.OpenRead(path))
            {
                var dat = ser.Deserialize(str) as List<CustomFlag>;
                if (dat == null) return;
                Custom = dat;
            }
        }

        internal static void AddModSettings(Mod mod)
        {
            Settings.AddHeader(mod, "Spawn Flags");
            Settings.AddButton(mod, "Spawn Lesbian Flag", delegate
            {
                var flag = Object.Instantiate(Presets[4]); // 5 stripes flag

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.SetType("lesbian");
            });
            Settings.AddButton(mod, "Spawn Gay Flag", delegate
            {
                var flag = Object.Instantiate(Presets[5]); // 6 stripes flag

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.SetType("gay");
            });
            Settings.AddButton(mod, "Spawn Bi Flag", delegate
            {
                var flag = Object.Instantiate(Presets[2]); // 3 stripes with middle one smaller

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.SetType("bi");
            });
            Settings.AddButton(mod, "Spawn Trans Flag", delegate // my flag :3
            {
                var flag = Object.Instantiate(Presets[4]); // 5 stripes

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.SetType("trans");
            });
            Settings.AddButton(mod, "Spawn Intersex Flag", delegate
            {
                var flag = Object.Instantiate(Presets[6]); // Intersex

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.preset = PrideFlag.PrideFlagPreset.Intersex;
            });
            Settings.AddButton(mod, "Spawn Queer Flag", delegate
            {
                var flag = Object.Instantiate(Presets[7]); // Queer

                flag.transform.position = Player.transform.position;
                var flagT = flag.AddComponent<PrideFlag>();

                flagT.preset = PrideFlag.PrideFlagPreset.Queer;
            });
            Settings.AddButton(mod, "Make your own pride flag", () =>
            {
                EditorData.Show = true;
                EditorData.Window = EditorCurrentWindow.List;
            });

            Settings.AddHeader(mod, "Manage Existing Flags");
            Settings.AddButton(mod, "Delete all flags", () =>
            {
                foreach (var flag in Object.FindObjectsOfType<PrideFlag>()) Object.Destroy(flag.gameObject);
            });
            Settings.AddButton(mod, "Delete save file", () =>
            {
                var path = Path.Combine(Application.persistentDataPath, "PrideFlags.xml");
                if (File.Exists(path))
                    File.Delete(path);
            });
            Settings.AddButton(mod, "Duplicate all the flags", () =>
            {
                foreach (var flag in Object.FindObjectsOfType<PrideFlag>())
                {
                    var duplicate = Object.Instantiate(flag.gameObject);
                    duplicate.name = flag.name;
                }
            });
        }
        
        
        internal static void SaveFlags()
        {
            var path = Path.Combine(Application.persistentDataPath, "PrideFlags.xml");
            if (File.Exists(path)) File.Delete(path);

            using (var stream = File.OpenWrite(path))
            {
                var serializer = new XmlSerializer(typeof(PrideFlagsData));
                var flags = new PrideFlagsData();

                foreach (var flag in Object.FindObjectsOfType<PrideFlag>())
                {
                    var flagTransform = flag.transform;
                    var flagPos = flagTransform.position;
                    var flagRot = flagTransform.rotation;

                    flags.Flags.Add(new PrideFlagData
                    {
                        Name = flag.name,
                        PosX = flagPos.x,
                        PosY = flagPos.y,
                        PosZ = flagPos.z,
                        RotX = flagRot.x,
                        RotZ = flagRot.z,
                        RotY = flagRot.y,
                        RotW = flagRot.w,
                        Colours = flag.colours,
                        Preset = flag.preset,
                        Size = flag.size
                    });
                }

                serializer.Serialize(stream, flags);
            }
        }
        
        
        internal static void LoadFlags()
        {
            var path = Path.Combine(Application.persistentDataPath, "PrideFlags.xml");
            if (!File.Exists(path)) return;
            using (var stream = File.OpenRead(path))
            {
                var serializer = new XmlSerializer(typeof(PrideFlagsData));
                var flags = serializer.Deserialize(stream) as PrideFlagsData;

                if (flags == null) return;

                foreach (var flag in flags.Flags)
                {
                    var flag2 = Object.Instantiate(Presets[(int)flag.Preset]);

                    flag2.transform.position = new Vector3(flag.PosX, flag.PosY, flag.PosZ);
                    flag2.transform.rotation = new Quaternion(flag.RotX, flag.RotY, flag.RotZ, flag.RotW);
                    var flagT = flag2.AddComponent<PrideFlag>();

                    flagT.name = flag.Name;
                    flagT.preset = flag.Preset;
                    if (flag.Preset == PrideFlag.PrideFlagPreset.Queer) continue;
                    flagT.SetColours(flag.Colours);
                }
            }
        }
        
        internal static AssetBundle ReadAssetBundle()
        {
            byte[] bytes;
            using (var s = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("PrideMod.Resources.prideflags.unity3d"))
            {
                bytes = new byte[s.Length];
                _ = s.Read(bytes, 0, bytes.Length);
            }

            if (bytes.Length == 0) throw new FileLoadException("Could not load prideflags.unity3d from DLL!");

            var assetBundle = AssetBundle.CreateFromMemoryImmediate(bytes);
            return assetBundle;
        }
    }
}