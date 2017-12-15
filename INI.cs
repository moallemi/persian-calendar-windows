using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RezaMoallemiUtilities.System32
{
    public class INI
    {

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileIntW", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileIntW(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Auto)]
        private static extern int WritePrivateProfileStringW(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileStringW(string lpApplicationName, string lpKeyName, string lpDefault, byte[] lpReturnedString, int nSize, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileSectionNamesW", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSectionNamesW(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileSectionW", CharSet = CharSet.Auto)]
        private static extern int WritePrivateProfileSectionW(string lpAppName, string lpString, string lpFileName);

        private string ls_IniFilename;
        private int li_BufferLen = 256;

        /// <summary>
        /// INI Constructor
        /// </summary>
        public INI(string pIniFilename)
        {
            ls_IniFilename = pIniFilename;
        }

        public INI()
        {
            ls_IniFilename = string.Empty;
        }

        /// <summary>
        /// INI filename (If no path is specifyed the function will look with-in the windows directory for the file)
        /// </summary>
        public string IniFile
        {
            get { return (ls_IniFilename); }
            set { ls_IniFilename = value; }
        }

        /// <summary>
        /// Max return length when reading data (Max: 32767)
        /// </summary>
        public int BufferLen
        {
            get { return li_BufferLen; }
            set
            {
                if (value > 32767) { li_BufferLen = 32767; }
                else if (value < 1) { li_BufferLen = 1; }
                else { li_BufferLen = value; }
            }
        }

        /// <summary>
        /// Read value from INI File
        /// </summary>
        public string GetValue(string pSection, string pKey, string pDefault)
        {

            return (z_GetString(pSection, pKey, pDefault));

        }

        /// <summary>
        /// Read value from INI File, default = ""
        /// </summary>
        public string GetValue(string pSection, string pKey)
        {
            return (z_GetString(pSection, pKey, ""));
        }

        /// <summary>
        /// Write value to INI File
        /// </summary>
        public void WriteValue(string pSection, string pKey, string pValue)
        {
            WritePrivateProfileStringW(pSection, pKey, pValue, this.ls_IniFilename);
        }

        /// <summary>
        /// Remove value from INI File
        /// </summary>
        public void RemoveValue(string pSection, string pKey)
        {

            WritePrivateProfileStringW(pSection, pKey, null, this.ls_IniFilename);

        }

        /// <summary>
        /// Read values in a section from INI File
        /// </summary>
        public string[] GetValues(string pSection)
        {
            return z_GetString(pSection, null, null).Split((char)0);
        }

        /// <summary>
        /// Read sections from INI File
        /// </summary>
        public void ReadSections(ref Array pSections)
        {
            pSections = z_GetString(null, null, null).Split((char)0);
        }

        /// <summary>
        /// Remove section from INI File
        /// </summary>
        public void RemoveSection(string pSection)
        {
            WritePrivateProfileStringW(pSection, null, null, this.ls_IniFilename);
        }

        /// <summary>
        /// Call GetPrivateProfileString / GetPrivateProfileStruct API
        /// </summary>
        private string z_GetString(string pSection, string pKey, string pDefault)
        {
            string sRet = pDefault;
            byte[] bRet = new byte[li_BufferLen];
            int i = GetPrivateProfileStringW(pSection, pKey, pDefault, bRet, li_BufferLen, ls_IniFilename);
            sRet = System.Text.Encoding.GetEncoding("Unicode").GetString(bRet, 0, i * 2).TrimEnd((char)0);
            return (sRet);
        }

    }
}
