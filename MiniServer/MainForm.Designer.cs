
namespace MiniServer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rinfo = new System.Windows.Forms.RichTextBox();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csMenuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.csMenuSetPort = new System.Windows.Forms.ToolStripMenuItem();
            this.csMenuSetWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.csMenuCSRF = new System.Windows.Forms.ToolStripMenuItem();
            this.csMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.csMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rinfo
            // 
            this.rinfo.BackColor = System.Drawing.SystemColors.WindowText;
            this.rinfo.ContextMenuStrip = this.cMenu;
            this.rinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rinfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rinfo.ForeColor = System.Drawing.SystemColors.Window;
            this.rinfo.Location = new System.Drawing.Point(0, 0);
            this.rinfo.Name = "rinfo";
            this.rinfo.ReadOnly = true;
            this.rinfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rinfo.Size = new System.Drawing.Size(978, 344);
            this.rinfo.TabIndex = 0;
            this.rinfo.Text = "";
            this.rinfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rinfo_LinkClicked);
            // 
            // cMenu
            // 
            this.cMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csMenuSet,
            this.csMenuAbout,
            this.csMenuExit});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(241, 127);
            // 
            // csMenuSet
            // 
            this.csMenuSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csMenuSetPort,
            this.csMenuSetWorkspace,
            this.csMenuCSRF});
            this.csMenuSet.Name = "csMenuSet";
            this.csMenuSet.Size = new System.Drawing.Size(240, 30);
            this.csMenuSet.Text = "设置(&S)";
            // 
            // csMenuSetPort
            // 
            this.csMenuSetPort.Name = "csMenuSetPort";
            this.csMenuSetPort.Size = new System.Drawing.Size(270, 34);
            this.csMenuSetPort.Text = "端口号(&P)";
            this.csMenuSetPort.Click += new System.EventHandler(this.csMenuSetPort_Click);
            // 
            // csMenuSetWorkspace
            // 
            this.csMenuSetWorkspace.Name = "csMenuSetWorkspace";
            this.csMenuSetWorkspace.Size = new System.Drawing.Size(270, 34);
            this.csMenuSetWorkspace.Text = "工作空间(&W)";
            this.csMenuSetWorkspace.Click += new System.EventHandler(this.csMenuSetWorkspace_Click_1);
            // 
            // csMenuCSRF
            // 
            this.csMenuCSRF.Name = "csMenuCSRF";
            this.csMenuCSRF.Size = new System.Drawing.Size(270, 34);
            this.csMenuCSRF.Text = "开启CSRF(&C)";
            this.csMenuCSRF.Click += new System.EventHandler(this.csMenuCSRF_Click);
            // 
            // csMenuAbout
            // 
            this.csMenuAbout.Name = "csMenuAbout";
            this.csMenuAbout.Size = new System.Drawing.Size(240, 30);
            this.csMenuAbout.Text = "关于(&A)";
            this.csMenuAbout.Click += new System.EventHandler(this.csMenuAbout_Click);
            // 
            // csMenuExit
            // 
            this.csMenuExit.Name = "csMenuExit";
            this.csMenuExit.Size = new System.Drawing.Size(240, 30);
            this.csMenuExit.Text = "退出(&E)";
            this.csMenuExit.Click += new System.EventHandler(this.csMenuExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "程序已经隐藏到系统托盘，双击图标即可重新唤起";
            this.notifyIcon.BalloonTipTitle = "迷你服务器";
            this.notifyIcon.ContextMenuStrip = this.cMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "迷你服务器";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 344);
            this.Controls.Add(this.rinfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "迷你服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rinfo;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem csMenuAbout;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem csMenuExit;
        private System.Windows.Forms.ToolStripMenuItem csMenuSet;
        private System.Windows.Forms.ToolStripMenuItem csMenuSetPort;
        private System.Windows.Forms.ToolStripMenuItem csMenuSetWorkspace;
        private System.Windows.Forms.ToolStripMenuItem csMenuCSRF;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

