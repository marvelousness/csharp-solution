using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniServer.Server;
using MiniServer.Server.Event;

namespace MiniServer
{
    public partial class MainForm : Form
    {
        private int port = 9090;
        /// <summary>
        /// 服务器对象
        /// </summary>
        private SimpleHttpServer server;
        /// <summary>
        /// 用于表示该程序已经通知过用户，程序退出到系统托盘，将不再弹出通知
        /// </summary>
        private bool notified = false;

        public MainForm()
        {
            InitializeComponent();
            this.server = new SimpleHttpServer();
            this.server.OnMessage += Server_OnMessage;
            this.server.OnRequest += Server_OnRequest;
        }

        private void Server_OnRequest(object sender, RequestEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Server_OnMessage(object sender, MessageEventArgs e)
        {
            this.Invoke(new Action<MessageEventArgs>(x =>
            {
                int sindex = this.rinfo.Text.Length;
                int length = e.Info.Length;
                this.rinfo.AppendText(e.Info);
                this.rinfo.SelectionStart = sindex;
                this.rinfo.SelectionLength = length;
                switch (e.Type)
                {
                    case EventType.Warn:
                        this.rinfo.SelectionColor = Color.Brown;
                        break;
                    case EventType.Error:
                        this.rinfo.SelectionColor = Color.Red;
                        break;
                    default:
                        this.rinfo.SelectionColor = Color.White;
                        break;
                }
                this.rinfo.Focus();
                this.rinfo.SelectionStart = this.rinfo.Text.Length;
            }), e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.server.Start(this.port);
        }

        private void csMenuAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            if (this.WindowState != FormWindowState.Normal)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }
            form.ShowDialog(this);
        }

        private void rinfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void csMenuExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;
            if (!this.notified)
            {
                this.notifyIcon.ShowBalloonTip(3000);
                this.notified = true;
            }
            e.Cancel = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.notifyIcon.Visible = false;
        }


        private void csMenuSetPort_Click(object sender, EventArgs e)
        {
            ChangePortForm form = new ChangePortForm(this.port);
            if (this.WindowState != FormWindowState.Normal) 
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }
            if (DialogResult.OK == form.ShowDialog(this))
            {
                this.port = form.Port;
                this.server.Stop();
                this.server.Start(this.port);
            }
        }

        private void csMenuSetWorkspace_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog.ShowDialog(this))
            {
                this.server.Workspace = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void csMenuCSRF_Click(object sender, EventArgs e)
        {
            this.rinfo.AppendText("This function is not open yet!\n");
            this.server.EnableCSRF = true;
        }
    }
}
