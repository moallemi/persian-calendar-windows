using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using FarsiLibrary.Utils;
using RezaMoallemiUtilities.System32;
using System.Threading;
using FarsiLibrary.Win.Controls;

namespace prlnd
{
    public partial class frmMain : Form
    {
        private StartupManager startup = new StartupManager("Persian Calandar", "Persian Calandar");
        private Settings setting = new Settings();

        public frmMain()
        {
            InitializeComponent();
            if (Environment.OSVersion.Version.Major > 5)
            {
                lblDate.Image = prlnd.Properties.Resources.gray;
                lblDate.ForeColor = Color.FromArgb(224, 224, 224);
            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            faMonthViewStrip1.FAMonthView.SelectedDateTime = (DateTime)PersianDate.Now;
            SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
            notifyIcon1.Text = lblSize.Text = lblDate.Text = toFarsi.Convert(new PersianDate(DateTime.Now).ToString("D"));
            startup.CheckStatus();
            mnuAutoRun.Checked = startup.IsRunningAtStartUp();
            mnuTrans.Checked = setting.Transparency;
            if (mnuTrans.Checked)
                Opacity = 0.6;
        }

        void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            notifyIcon1.Text = lblSize.Text = lblDate.Text = toFarsi.Convert(new PersianDate(DateTime.Now).ToString("D"));
            lblDate.Size = new Size(lblSize.Size.Width, 18);
            this.Size = lblDate.Size;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDate.Size = new Size(lblSize.Size.Width, 18);
            this.Size = lblDate.Size;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
            if (setting.ShowDate)
            {
                mnuShow.Checked = true;
            }
            else
            {
                mnuShow.Checked = false;
                this.Visible = false;
                this.Hide();
            }
        }

        private void mnuAutoRun_Click(object sender, EventArgs e)
        {
            if (startup.IsRunningAtStartUp())
                startup.DisableRunAtStartUp();
            else
                startup.EnableRunAtStartUp();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Environment.Exit(Environment.ExitCode);
        }

        private void mnuShamsi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (itm.Text == "تبدیل تاریخ میلادی به شمسی")
                new frmConvert("en").ShowDialog();
            else
                new frmConvert("fa").ShowDialog();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            faMonthViewStrip1.FAMonthView.SelectedDateTime = (DateTime)PersianDate.Now;
        }

        private void mnuShow_Click(object sender, EventArgs e)
        {
            if (mnuShow.Checked)
            {
                setting.ShowDate = true;
                this.Show();
            }
            else 
            {
                setting.ShowDate = false;
                this.Hide();
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void timer_transparent_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.05;
        }

        private void lblDate_MouseEnter(object sender, EventArgs e)
        {
            SystemEvents_TimeChanged(null, null);
            if (mnuTrans.Checked)
            {
                timer_transparent.Enabled = true;
                timer_transparent_down.Enabled = false;
            }
        }

        private void timer_transparent_down_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 0.6)
                timer_transparent_down.Stop();
            else
                this.Opacity -= 0.05;
        }

        private void lblDate_MouseLeave(object sender, EventArgs e)
        {
            if (mnuTrans.Checked)
            {
                timer_transparent.Enabled = false;
                timer_transparent_down.Enabled = true;
            }
        }

        private void mnuTrans_Click(object sender, EventArgs e)
        {
            if (mnuTrans.Checked)
            {
                setting.Transparency = true;
                this.Opacity = 0.6;
            }
            else
            {
                setting.Transparency = false;
                this.Opacity = 1;
            }
        }

    }
}