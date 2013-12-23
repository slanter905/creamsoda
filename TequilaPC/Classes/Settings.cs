using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Drawing;

namespace Tequila
{
    class Settings
    {

        public static bool SetupNeeded {
            get {
                return GamePath == "" || !File.Exists(Path.Combine(GamePath, "icon.exe"));
            }
        }

        public static string GamePath
        {
            get
            {
                FixRegistryPolution();
                return TequilaRegistry.GetValue("CoHPath", "").ToString();
            }
            set
            {
                TequilaRegistry.SetValue("CoHPath", value);
            }
        }

        public static bool QuitOnLaunch
        {
            get
            {

                return TequilaRegistry.GetValue("QuitOnLaunch", "FALSE").ToString().ToUpper() == "TRUE";
            }
            set
            {
                if(value) 
                    TequilaRegistry.SetValue("QuitOnLaunch", "TRUE");
                else
                    TequilaRegistry.SetValue("QuitOnLaunch", "FALSE");
            }
        }

        public static string GameParams
        {
            get
            {
                return TequilaRegistry.GetValue("Parameters", "").ToString();
            }
            set
            {
                TequilaRegistry.SetValue("Parameters", value);
            }
        }

        public static Color BGColor
        {
            get
            {
                int color;
                bool success = int.TryParse(TequilaRegistry.GetValue("BGColor", -13017488).ToString(), out color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                TequilaRegistry.SetValue("BGColor", value.ToArgb());
            }
        }

        public static Color TextColor
        {
            get
            {
                int color;
                bool success = int.TryParse(TequilaRegistry.GetValue("TextColor", -1).ToString(), out color);
                if (success) return Color.FromArgb(color);
                else return Color.Black;
            }
            set
            {
                TequilaRegistry.SetValue("TextColor", value.ToArgb());
            }
        }




        public static void Reset() {
            TequilaRegistry.DeleteValue("CoHPath");
        }

        private static RegistryKey TequilaRegistry {
            get
            {
                RegistryKey r = Registry.CurrentUser.OpenSubKey(@"Software\Tequila\Settings", true);

                if (r == null)
                {
                    r = Registry.CurrentUser.CreateSubKey(@"Software\Tequila\Settings");
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
            catch (Exception ex) { }
        }


    }
}
