using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowRename
{
    public partial class MainForm : Form
    {
        private Renamer renamer = new Renamer();
        public MainForm()
        {
            InitializeComponent();
            this.ofd.InitialDirectory = Application.StartupPath;
            this.ofd.InitialDirectory = @"D:\Users\marvelousness\Desktop\x";
            this.renamer.Finish += Renamer_Finish;
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            DialogResult result = this.ofd.ShowDialog();
            if (DialogResult.OK.Equals(result)) 
            {
                this.txt_files.Text = String.Join(", ", this.ofd.SafeFileNames);

                this.lvs.Items.Clear();
                foreach (string name in this.ofd.FileNames)
                {
                    string[] ns = name.Split(Path.DirectorySeparatorChar);
                    string text = ns.Length > 0 ? ns[ns.Length - 1] : name;
                    ListViewItem item = new ListViewItem(text);
                    item.Tag = name;
                    item.SubItems.Add("已发现", Color.Black, Color.Transparent, new Font(FontFamily.GenericSerif, 12.0f));
                    this.lvs.Items.Add(item);
                }
                this.sc.Panel2Collapsed = false;
            }
        }

        private void Renamer_Finish(object sender, RenameEventArgs args)
        {
            string status = "处理中";
            switch (args.status)
            {
                case RenameEventStatus.Readied:
                    status = "处理中";
                    break;
                case RenameEventStatus.Completed:
                    status = "已完成";
                    break;
                case RenameEventStatus.FileNotFound:
                    status = "文件丢失";
                    break;
                case RenameEventStatus.Canceled:
                    status = "已取消" + (string.IsNullOrEmpty(args.exception) ? "" : "，原因是：" + args.exception);
                    break;
                case RenameEventStatus.Error:
                    status = "已出错，原因是：" + args.exception;
                    break;
            }
            this.lvs.Items[args.index].SubItems[1].Text = status;
        }

        private void tsMenu_replace_Click(object sender, EventArgs e)
        {
            string[] names = this.ofd.FileNames;
            if (names.Length < 1)
            {
                return;
            }
            this.renamer.Replace(this.txt_raw.Text, this.txt_new.Text, names);
        }

        private void tsMenu_index_Click(object sender, EventArgs e)
        {
            string[] names = this.txt_new.Text.Replace("{i}", "\n").Split('\n');
            string prefix = "";
            string suffix = "";
            if (names.Length == 2) 
            {
                prefix = names[0];
                suffix = names[1];
            }
            this.renamer.Index(prefix, suffix, this.ofd.FileNames);
        }
    }
}
