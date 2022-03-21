
namespace WindowRename
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
            this.sc = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_files = new System.Windows.Forms.TextBox();
            this.txt_raw = new System.Windows.Forms.TextBox();
            this.txt_new = new System.Windows.Forms.TextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lvs = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenu_replace = new System.Windows.Forms.ToolStripMenuItem();
            this.ch_filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMenu_index = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sc
            // 
            this.sc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc.Location = new System.Drawing.Point(0, 0);
            this.sc.Name = "sc";
            this.sc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.btn_browser);
            this.sc.Panel1.Controls.Add(this.txt_new);
            this.sc.Panel1.Controls.Add(this.txt_raw);
            this.sc.Panel1.Controls.Add(this.txt_files);
            this.sc.Panel1.Controls.Add(this.label3);
            this.sc.Panel1.Controls.Add(this.label2);
            this.sc.Panel1.Controls.Add(this.label1);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.lvs);
            this.sc.Size = new System.Drawing.Size(578, 394);
            this.sc.SplitterDistance = 188;
            this.sc.SplitterWidth = 6;
            this.sc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "原文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "新名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "原名称：";
            // 
            // txt_files
            // 
            this.txt_files.Location = new System.Drawing.Point(135, 39);
            this.txt_files.Name = "txt_files";
            this.txt_files.ReadOnly = true;
            this.txt_files.Size = new System.Drawing.Size(297, 28);
            this.txt_files.TabIndex = 3;
            // 
            // txt_raw
            // 
            this.txt_raw.Location = new System.Drawing.Point(135, 85);
            this.txt_raw.Name = "txt_raw";
            this.txt_raw.Size = new System.Drawing.Size(405, 28);
            this.txt_raw.TabIndex = 4;
            // 
            // txt_new
            // 
            this.txt_new.Location = new System.Drawing.Point(135, 131);
            this.txt_new.Name = "txt_new";
            this.txt_new.Size = new System.Drawing.Size(405, 28);
            this.txt_new.TabIndex = 5;
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(450, 39);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(90, 28);
            this.btn_browser.TabIndex = 6;
            this.btn_browser.Text = "浏览(&B)";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // ofd
            // 
            this.ofd.Multiselect = true;
            this.ofd.Title = "请选择需要修改名称的原文件";
            // 
            // lvs
            // 
            this.lvs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_filename,
            this.ch_status});
            this.lvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvs.FullRowSelect = true;
            this.lvs.HideSelection = false;
            this.lvs.Location = new System.Drawing.Point(0, 0);
            this.lvs.Name = "lvs";
            this.lvs.Size = new System.Drawing.Size(578, 200);
            this.lvs.TabIndex = 0;
            this.lvs.UseCompatibleStateImageBehavior = false;
            this.lvs.View = System.Windows.Forms.View.Details;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu_replace,
            this.tsMenu_index});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(207, 64);
            // 
            // tsMenu_replace
            // 
            this.tsMenu_replace.Name = "tsMenu_replace";
            this.tsMenu_replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsMenu_replace.Size = new System.Drawing.Size(206, 30);
            this.tsMenu_replace.Text = "替换(&R)";
            this.tsMenu_replace.Click += new System.EventHandler(this.tsMenu_replace_Click);
            // 
            // ch_filename
            // 
            this.ch_filename.Text = "文件名";
            this.ch_filename.Width = 275;
            // 
            // ch_status
            // 
            this.ch_status.Text = "状态";
            this.ch_status.Width = 89;
            // 
            // tsMenu_index
            // 
            this.tsMenu_index.Name = "tsMenu_index";
            this.tsMenu_index.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsMenu_index.Size = new System.Drawing.Size(206, 30);
            this.tsMenu_index.Text = "序列(&I)";
            this.tsMenu_index.Click += new System.EventHandler(this.tsMenu_index_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 394);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.sc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 文件重命名";
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel1.PerformLayout();
            this.sc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_files;
        private System.Windows.Forms.TextBox txt_raw;
        private System.Windows.Forms.TextBox txt_new;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ListView lvs;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_replace;
        private System.Windows.Forms.ColumnHeader ch_filename;
        private System.Windows.Forms.ColumnHeader ch_status;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_index;
    }
}

