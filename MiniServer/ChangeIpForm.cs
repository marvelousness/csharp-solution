using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace MiniServer
{
    public partial class ChangeIpForm : Form
    {
        private readonly string ip;
        public ChangeIpForm(string ip = "localhost")
        {
            InitializeComponent();
            this.coBoxIp.Text = ip;
            this.ip = ip;
            this.coBoxIp.Items.Add("localhost");
            this.coBoxIp.Items.Add("127.0.0.1");
        }
        /// <summary>
        /// 所选IP
        /// </summary>
        public string Ip
        {
            get
            {
                return this.coBoxIp.Text;
            }
        }
        /// <summary>
        /// IP的值是否发生变化
        /// </summary>
        public bool Changed { get => !this.Ip.Equals(this.ip); }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = this.Changed ? DialogResult.OK : DialogResult.No;
            this.Close();
        }

        private void ChangeIpForm_Load(object sender, EventArgs e)
        {
            string name = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(name);
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    // this.coBoxIp.Items.Add(address.ToString());
                }
            }
        }
    }
}
