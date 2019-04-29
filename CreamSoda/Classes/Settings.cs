using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Drawing;

namespace CreamSoda
{
    class Settings
    {

        public static bool SetupNeeded {
            get {
                return GamePath == "" || !File.Exists(Path.Combine(GamePath, "CreamSoda.exe"));
            }
        }

        public static string GamePath
        {
            get
            {
                FixRegistryPolution();
                return CreamSodaRegistry.GetValue("CoHPath", "").ToString();
            }
            set
            {
                CreamSodaRegistry.SetValue("CoHPath", value);
            }
        }

        public static bool QuitOnLaunch
        {
            get
            {

                return CreamSodaRegistry.GetValue("QuitOnLaunch", "FALSE").ToString().ToUpper() == "TRUE";
            }
            set
            {
                if(value) 
                    CreamSodaRegistry.SetValue("QuitOnLaunch", "TRUE");
                else
                    CreamSodaRegistry.SetValue("QuitOnLaunch", "FALSE");
            }
        }

        public static string GameParams
        {
            get
            {
                return CreamSodaRegistry.GetValue("Parameters", "").ToString();
            }
            set
            {
                CreamSodaRegistry.SetValue("Parameters", value);
            }
        }

        public static Color BGColor
        {
            get
            {
                bool success = int.TryParse(CreamSodaRegistry.GetValue("BGColor", SystemColors.Control.ToArgb()).ToString(), out int color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                CreamSodaRegistry.SetValue("BGColor", value.ToArgb());
            }
        }

        public static Color TextColor
        {
            get
            {
                bool success = int.TryParse(CreamSodaRegistry.GetValue("TextColor", SystemColors.ControlText.ToArgb()).ToString(), out int color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                CreamSodaRegistry.SetValue("TextColor", value.ToArgb());
            }
        }

        public static Color ListColor
        {
            get
            {
                bool success = int.TryParse(CreamSodaRegistry.GetValue("ListColor", SystemColors.Window.ToArgb()).ToString(), out int color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                CreamSodaRegistry.SetValue("TextColor", value.ToArgb());
            }
        }

        public static Color ListTextColor
        {
            get
            {
                bool success = int.TryParse(CreamSodaRegistry.GetValue("ListTextColor", SystemColors.WindowText.ToArgb()).ToString(), out int color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                CreamSodaRegistry.SetValue("ListTextColor", value.ToArgb());
            }
        }

        public static List<string> Manifests
        {
            get
            {
                char[] splitChars = {'\n'};
                return CreamSodaRegistry.GetValue("Manifests", "").ToString().Split(splitChars, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            }
            set
            {
                string strManifests = "";
                foreach (string Manifest in value)
                {
                    strManifests += Manifest.Trim() + "\n";
                }

                if (strManifests.EndsWith("\n")) strManifests = strManifests.Substring(0, strManifests.Length - 1);
                CreamSodaRegistry.SetValue("Manifests", strManifests);
            }
        }

        public static string LastManifest
        {
            get
            {
                return CreamSodaRegistry.GetValue("LastManifest", "").ToString();
            }
            set
            {
                CreamSodaRegistry.SetValue("LastManifest", value);
            }
        }

        public static void Reset() {
            CreamSodaRegistry.DeleteValue("CoHPath");
        }

        private static RegistryKey CreamSodaRegistry {
            get
            {
                RegistryKey r = Registry.CurrentUser.OpenSubKey(@"Software\CreamSoda\Settings", true);

                if (r == null)
                {
                    r = Registry.CurrentUser.CreateSubKey(@"Software\CreamSoda\Settings");
                }

                return r;
            }
        }

        private static void FixRegistryPolution()
        {
            try
            {
                string s = Registry.CurrentUser.GetValue("CoHPath", "").ToString();
                if (s != "")
                {
                    GamePath = s;
                    Registry.CurrentUser.DeleteValue("CoHPath");
                }
            }
            catch (Exception) { }
        }



    }
}
