namespace WifiConnector
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbox = new System.Windows.Forms.ListBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuItemConnector = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuItemDecipher = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.cmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbox
            // 
            this.lbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbox.ContextMenuStrip = this.cmenu;
            this.lbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbox.FormattingEnabled = true;
            this.lbox.ItemHeight = 16;
            this.lbox.Location = new System.Drawing.Point(0, 0);
            this.lbox.Name = "lbox";
            this.lbox.Size = new System.Drawing.Size(354, 131);
            this.lbox.TabIndex = 9;
            this.lbox.SelectedIndexChanged += new System.EventHandler(this.lbox_SelectedIndexChanged);
            this.lbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbox_MouseDoubleClick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslInfo});
            this.statusBar.Location = new System.Drawing.Point(0, 131);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(354, 22);
            this.statusBar.TabIndex = 12;
            this.statusBar.Text = "statusStrip1";
            // 
            // tsslInfo
            // 
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(138, 17);
            this.tsslInfo.Text = "欢迎使用 WIFI 连接工具";
            // 
            // cmenu
            // 
            this.cmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuItemRefresh,
            this.cmenuItemConnector,
            this.cmenuItemDecipher});
            this.cmenu.Name = "cmenu";
            this.cmenu.Size = new System.Drawing.Size(164, 70);
            // 
            // cmenuItemRefresh
            // 
            this.cmenuItemRefresh.Name = "cmenuItemRefresh";
            this.cmenuItemRefresh.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.cmenuItemRefresh.Size = new System.Drawing.Size(163, 22);
            this.cmenuItemRefresh.Text = "刷新(&R)";
            this.cmenuItemRefresh.Click += new System.EventHandler(this.cmenuItemRefresh_Click);
            // 
            // cmenuItemConnector
            // 
            this.cmenuItemConnector.Name = "cmenuItemConnector";
            this.cmenuItemConnector.Size = new System.Drawing.Size(163, 22);
            this.cmenuItemConnector.Text = "连接(&C)";
            this.cmenuItemConnector.Click += new System.EventHandler(this.cmenuItemConnector_Click);
            // 
            // cmenuItemDecipher
            // 
            this.cmenuItemDecipher.Name = "cmenuItemDecipher";
            this.cmenuItemDecipher.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.cmenuItemDecipher.Size = new System.Drawing.Size(163, 22);
            this.cmenuItemDecipher.Text = "破解(&D)";
            this.cmenuItemDecipher.Click += new System.EventHandler(this.cmenuItemDecipher_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 153);
            this.Controls.Add(this.lbox);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIFI 连接器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.cmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbox;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfo;
        private System.Windows.Forms.ContextMenuStrip cmenu;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemConnector;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemDecipher;
    }
}

