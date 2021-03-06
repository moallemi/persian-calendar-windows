using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FarsiLibrary.Utils;

namespace prlnd
{
    public partial class frmConvert : Form
    {
        private string culture;
        public frmConvert(string culture)
        {
            InitializeComponent();
            this.culture = culture;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
            if (culture == "fa")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                faDatePicker1.Text = PersianDate.Now.ToString("d");
                this.Text = "تبدیل تاریخ شمسی به میلادی";
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                faDatePicker1.Text = DateTime.Now.ToString("D");
                this.Text = "تبدیل تاریخ میلادی به شمسی";
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (culture =="fa")
                lblConvert.Text = ((DateTime)faDatePicker1.SelectedDateTime).ToString("d");
            else
                lblConvert.Text = toFarsi.Convert(((PersianDate)faDatePicker1.SelectedDateTime).ToString("D"));
        }
    }
}