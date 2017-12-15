using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RezaMoallemiUtilities.System32
{
    public class StartupManager
    {
        public delegate void StartupEventHandler();
        public event StartupEventHandler onEnableStartup;
        public event StartupEventHandler onDisableStartup;

        private bool askStartup = true;
        private string progkey;
        private string progname;

        public string ProgramName
        {
            get { return progname; }
            set { progname = value; }
        }
        
        public string ProgramKey
        {
            get { return progkey; }
            set { progkey = value; }
        }
	
        public bool AskAtFirstTime
        {
            get { return askStartup; }
            set { askStartup = value; }
        }


        public StartupManager(string programName, string programKey)
        {
            progname = programName;
            progkey = programKey;

        }
                
        private bool DoesValueExist(RegistryHive Root, string path, string valuename)
        {
            try
            {
                RegistryKey Key = RegistryKey.OpenRemoteBaseKey(Root, Environment.MachineName).OpenSubKey(path, true);
                if (Key == null)
                    return false;
                string[] valueNames = Key.GetValueNames();
                for (int i = 0; i < valueNames.Length; i++)
                    if (valuename == valueNames[i])
                        return true;
                    else if (i == valueNames.Length)
                        return false;
            }
            catch
            {
                MessageBox.Show("This progtram has encountered a problem and needs to close.\nI'm sorry for the inconvenience.", "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return false;
        }

        public bool IsRunningAtStartUp()
        {
            RegistryKey Key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, Environment.MachineName).OpenSubKey(@"Software", true).CreateSubKey(progkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (DoesValueExist(RegistryHive.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Run", progkey))
            {
                try { Key.SetValue("AutoStart", 1); }
                catch { }
                return true;
            }
            else
            {
                try { Key.SetValue("AutoStart", 0); }
                catch { }
                return false;
            }
        }

        public void EnableRunAtStartUp()
        {
            try
            {
                RegistryKey Key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, Environment.MachineName).OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                Key.SetValue(progkey, Application.ExecutablePath);
                if (onEnableStartup != null)
                    onEnableStartup();
            }
            catch (Exception)
            {
                MessageBox.Show(progname + "has encountered a problem and needs to close.\nI'm sorry for the inconvenience.", progname, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void DisableRunAtStartUp()
        {
            try
            {
                RegistryKey Key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, Environment.MachineName).OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                foreach (string name in Key.GetValueNames())
                    if (name == progkey)
                        Key.DeleteValue(progkey);
                if (onDisableStartup != null)
                    onDisableStartup();
            }
            catch (Exception)
            {
                MessageBox.Show(progname + "has encountered a problem and needs to close.\nI'm sorry for the inconvenience.", progname, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void CheckStatus()
        {
            RegistryKey Key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, Environment.MachineName).OpenSubKey(@"Software", true).CreateSubKey(progkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            try
            {
                if ((int)Key.GetValue("AutoStart", 2) == 2)
                {
                    if (MessageBox.Show("Would you like " + progname + " automatically starts at System StartUp?", progname, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes && askStartup)
                    {
                        Key.SetValue("AutoStart", 1);
                        EnableRunAtStartUp();
                    }
                    else
                        Key.SetValue("AutoStart", 0);
                }
            }
            catch (NullReferenceException)
            {
                Key.SetValue("AutoStart", 1);
                EnableRunAtStartUp();
            }
        }
    }
}


