using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RezaMoallemiUtilities.System32;
using System.Reflection;

namespace prlnd
{
    class Settings
    {
        private INI iniFile = new INI();

        public string AssemblyFileVersion
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }

        public Settings()
        {
            CheckSettings();
        }

        public bool Transparency
        {
            get
            {
                CheckSettings();
                return Convert.ToBoolean(iniFile.GetValue("Main", "Transparency", "True"));
            }
            set
            {
                iniFile.WriteValue("Main", "Transparency", value.ToString());
            }
        }

        public bool ShowDate
        {
            get
            {
                CheckSettings();
                return Convert.ToBoolean(iniFile.GetValue("Main", "ShowDate", "True"));
            }
            set
            {
                iniFile.WriteValue("Main", "ShowDate", value.ToString());
            }
        }

        private void CheckSettings()
        {
            string appdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Persian Calendar\\" + AssemblyFileVersion + "\\");
            string appfile = appdir + "prclnd.set";
            Directory.CreateDirectory(appdir);
            iniFile.IniFile = appfile;
            if (!File.Exists(appfile))
            {
                File.WriteAllText(appfile, "", Encoding.Unicode);
            }
        }
    }
}
