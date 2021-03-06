namespace prlnd
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblDate = new System.Windows.Forms.Label();
            this.cmnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPersianCalendar = new System.Windows.Forms.ToolStripMenuItem();
            this.faMonthViewStrip1 = new FarsiLibrary.Win.Controls.FaMonthViewStrip();
            this.mnuChangeDate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMiladi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShamsi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblSize = new System.Windows.Forms.Label();
            this.timer_transparent = new System.Windows.Forms.Timer(this.components);
            this.timer_transparent_down = new System.Windows.Forms.Timer(this.components);
            this.cmnuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblDate.ContextMenuStrip = this.cmnuTray;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Navy;
            this.lblDate.Image = global::prlnd.Properties.Resources.blue;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 18);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate.MouseLeave += new System.EventHandler(this.lblDate_MouseLeave);
            this.lblDate.MouseEnter += new System.EventHandler(this.lblDate_MouseEnter);
            // 
            // cmnuTray
            // 
            this.cmnuTray.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.mnuTrans,
            this.toolStripSeparator2,
            this.mnuPersianCalendar,
            this.mnuChangeDate,
            this.toolStripSeparator1,
            this.mnuAutoRun,
            this.mnuAbout,
            this.mnuExit});
            this.cmnuTray.Name = "contextMenuStrip1";
            this.cmnuTray.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmnuTray.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmnuTray.Size = new System.Drawing.Size(144, 170);
            // 
            // mnuShow
            // 
            this.mnuShow.CheckOnClick = true;
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(143, 22);
            this.mnuShow.Text = "نمایش تاریخ";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // mnuTrans
            // 
            this.mnuTrans.CheckOnClick = true;
            this.mnuTrans.Name = "mnuTrans";
            this.mnuTrans.Size = new System.Drawing.Size(143, 22);
            this.mnuTrans.Text = "شفافیت";
            this.mnuTrans.Click += new System.EventHandler(this.mnuTrans_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // mnuPersianCalendar
            // 
            this.mnuPersianCalendar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faMonthViewStrip1});
            this.mnuPersianCalendar.Name = "mnuPersianCalendar";
            this.mnuPersianCalendar.Size = new System.Drawing.Size(143, 22);
            this.mnuPersianCalendar.Text = "تقویم شمسی";
            // 
            // faMonthViewStrip1
            // 
            this.faMonthViewStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.faMonthViewStrip1.Name = "faMonthViewStrip1";
            this.faMonthViewStrip1.Size = new System.Drawing.Size(166, 166);
            // 
            // mnuChangeDate
            // 
            this.mnuChangeDate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMiladi,
            this.mnuShamsi});
            this.mnuChangeDate.Name = "mnuChangeDate";
            this.mnuChangeDate.Size = new System.Drawing.Size(143, 22);
            this.mnuChangeDate.Text = "تبدیل تاریخ...";
            // 
            // mnuMiladi
            // 
            this.mnuMiladi.Name = "mnuMiladi";
            this.mnuMiladi.Size = new System.Drawing.Size(214, 22);
            this.mnuMiladi.Text = "تبدیل تاریخ شمسی به میلادی";
            this.mnuMiladi.Click += new System.EventHandler(this.mnuShamsi_Click);
            // 
            // mnuShamsi
            // 
            this.mnuShamsi.Name = "mnuShamsi";
            this.mnuShamsi.Size = new System.Drawing.Size(214, 22);
            this.mnuShamsi.Text = "تبدیل تاریخ میلادی به شمسی";
            this.mnuShamsi.Click += new System.EventHandler(this.mnuShamsi_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // mnuAutoRun
            // 
            this.mnuAutoRun.Checked = true;
            this.mnuAutoRun.CheckOnClick = true;
            this.mnuAutoRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuAutoRun.Name = "mnuAutoRun";
            this.mnuAutoRun.Size = new System.Drawing.Size(143, 22);
            this.mnuAutoRun.Text = "اجرای خودکار";
            this.mnuAutoRun.Click += new System.EventHandler(this.mnuAutoRun_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(143, 22);
            this.mnuAbout.Text = "درباره...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(143, 22);
            this.mnuExit.Text = "خروج";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmnuTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(251, 46);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "label1";
            this.lblSize.Visible = false;
            // 
            // timer_transparent
            // 
            this.timer_transparent.Interval = 50;
            this.timer_transparent.Tick += new System.EventHandler(this.timer_transparent_Tick);
            // 
            // timer_transparent_down
            // 
            this.timer_transparent_down.Interval = 50;
            this.timer_transparent_down.Tick += new System.EventHandler(this.timer_transparent_down_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(298, 76);
            this.ControlBox = false;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSize);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Persain Calendar";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmnuTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmnuTray;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ToolStripMenuItem mnuPersianCalendar;
        private FarsiLibrary.Win.Controls.FaMonthViewStrip faMonthViewStrip1;
        private System.Windows.Forms.Timer timer_transparent;
        private System.Windows.Forms.Timer timer_transparent_down;
        private System.Windows.Forms.ToolStripMenuItem mnuTrans;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeDate;
        private System.Windows.Forms.ToolStripMenuItem mnuMiladi;
        private System.Windows.Forms.ToolStripMenuItem mnuShamsi;
    }
}

