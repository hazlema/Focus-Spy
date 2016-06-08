namespace FocusSpy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvProcs = new exListView();
            this.txtName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.togggleFocusWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.killProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctcFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.processesUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbProcesses = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbAttacks = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            lvProcs = new FocusSpy.exListView();

            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProcs
            // 
            lvProcs.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvProcs.AltColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            lvProcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            lvProcs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvProcs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.txtName,
            this.txtPID});
            lvProcs.ContextMenuStrip = this.contextMenuStrip1;
            lvProcs.Dock = System.Windows.Forms.DockStyle.Fill;
            lvProcs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lvProcs.ForeColor = System.Drawing.Color.WhiteSmoke;
            lvProcs.FullRowSelect = true;
            lvProcs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lvProcs.LargeImageList = this.imageList1;
            lvProcs.Location = new System.Drawing.Point(0, 0);
            lvProcs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvProcs.MultiSelect = false;
            lvProcs.Name = "lvProcs";
            lvProcs.OwnerDraw = true;
            lvProcs.Size = new System.Drawing.Size(301, 228);
            lvProcs.SmallImageList = this.imageList1;
            lvProcs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvProcs.TabIndex = 1;
            lvProcs.UseCompatibleStateImageBehavior = false;
            lvProcs.View = System.Windows.Forms.View.Details;
            lvProcs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.processList_ColumnClick);
            lvProcs.DoubleClick += new System.EventHandler(this.processList_DoubleClick);
            // 
            // txtName
            // 
            this.txtName.Text = "Name";
            this.txtName.Width = 200;
            // 
            // txtPID
            // 
            this.txtPID.Text = "PID";
            this.txtPID.Width = 75;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.togggleFocusWatchToolStripMenuItem,
            this.toolStripMenuItem1,
            this.killProcessToolStripMenuItem,
            this.ctcFocus});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 76);
            // 
            // togggleFocusWatchToolStripMenuItem
            // 
            this.togggleFocusWatchToolStripMenuItem.Name = "togggleFocusWatchToolStripMenuItem";
            this.togggleFocusWatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.togggleFocusWatchToolStripMenuItem.Text = "Enable Focus Watch";
            this.togggleFocusWatchToolStripMenuItem.Click += new System.EventHandler(this.ctxAddWatch);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // killProcessToolStripMenuItem
            // 
            this.killProcessToolStripMenuItem.Name = "killProcessToolStripMenuItem";
            this.killProcessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.killProcessToolStripMenuItem.Text = "Kill Process";
            this.killProcessToolStripMenuItem.Click += new System.EventHandler(this.ctxKill);
            // 
            // ctcFocus
            // 
            this.ctcFocus.Name = "ctcFocus";
            this.ctcFocus.Size = new System.Drawing.Size(180, 22);
            this.ctcFocus.Text = "Focus Application";
            this.ctcFocus.Click += new System.EventHandler(this.ctxFocus);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "off_16x16.gif");
            this.imageList1.Images.SetKeyName(1, "on_16x16.gif");
            this.imageList1.Images.SetKeyName(2, "stop_16x16.gif");
            // 
            // processesUpdateTimer
            // 
            this.processesUpdateTimer.Enabled = true;
            this.processesUpdateTimer.Interval = 1000;
            this.processesUpdateTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbProcesses,
            this.sbAttacks,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(301, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbProcesses
            // 
            this.sbProcesses.AutoSize = false;
            this.sbProcesses.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbProcesses.Name = "sbProcesses";
            this.sbProcesses.Size = new System.Drawing.Size(115, 17);
            this.sbProcesses.Text = "Loading";
            this.sbProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sbAttacks
            // 
            this.sbAttacks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAttacks.Name = "sbAttacks";
            this.sbAttacks.Size = new System.Drawing.Size(137, 17);
            this.sbAttacks.Spring = true;
            this.sbAttacks.Text = "Focus Attacks: 0";
            this.sbAttacks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuViewLog,
            this.mnuTop,
            this.mnuScroll,
            this.toolStripMenuItem2,
            this.mnuStartup});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(207, 22);
            this.mnuHelp.Text = "How-to Stop Focus Theft";
            this.mnuHelp.Click += new System.EventHandler(this.menuHelp);
            // 
            // mnuViewLog
            // 
            this.mnuViewLog.Name = "mnuViewLog";
            this.mnuViewLog.Size = new System.Drawing.Size(207, 22);
            this.mnuViewLog.Text = "View Log";
            this.mnuViewLog.Click += new System.EventHandler(this.menuLog);
            // 
            // mnuTop
            // 
            this.mnuTop.Checked = true;
            this.mnuTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTop.Name = "mnuTop";
            this.mnuTop.Size = new System.Drawing.Size(207, 22);
            this.mnuTop.Text = "Stay on Top";
            this.mnuTop.Click += new System.EventHandler(this.menuTop);
            // 
            // mnuScroll
            // 
            this.mnuScroll.Checked = true;
            this.mnuScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuScroll.Name = "mnuScroll";
            this.mnuScroll.Size = new System.Drawing.Size(207, 22);
            this.mnuScroll.Text = "Auto Scrolling";
            this.mnuScroll.Click += new System.EventHandler(this.menuScroll);
            // 
            // mnuStartup
            // 
            this.mnuStartup.Name = "mnuStartup";
            this.mnuStartup.Size = new System.Drawing.Size(207, 22);
            this.mnuStartup.Text = "Start with Windows";
            this.mnuStartup.Click += new System.EventHandler(this.mnuStartup_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem2";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 250);
            this.Controls.Add(lvProcs);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Focus Spy";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer processesUpdateTimer;
        private FocusSpy.exListView lvProcs;
        private System.Windows.Forms.ColumnHeader txtName;
        private System.Windows.Forms.ColumnHeader txtPID;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbProcesses;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuTop;
        private System.Windows.Forms.ToolStripMenuItem mnuScroll;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripStatusLabel sbAttacks;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem togggleFocusWatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctcFocus;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuStartup;
    }
}

