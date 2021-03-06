using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FarsiLibrary.Win.Controls;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace prlnd
{
    static class Program
    {

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int WS_SHOWNORMAL = 1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        public static void Main()
        {
            Process instance = RunningInstance();
            if (instance == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                frmMain main = new frmMain();
                if (new Settings().ShowDate)
                    main.Show();
                Application.Run();
            }
            else
                HandleRunningInstance(instance);
        }
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                        return process;

            }
            return null;
        }

        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            FAMessageBox mbx = FAMessageBoxManager.CreateMessageBox("BasicMessageBox", true);
            mbx.AddButton(new FAMessageBoxButton("خروج", "YES"));
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMain));
            mbx.CustomIcon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            mbx.Text = "تقویم هجری شمسی با مشکلی پیش بینی نشده روبه رو شده است و باید بسته شود.از وقفه پش آمده متاسفم.لطفا برای رفع این مشکل برنامه را دوباره اجرا کنید.";
            mbx.Caption = "تقویم هجری شمسی";
            mbx.Show();
            FAMessageBoxManager.DeleteMessageBox("BasicMessageBox");
            Environment.Exit(Environment.ExitCode);
        }
    }
}