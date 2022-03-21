using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniServer
{
    public partial class ChangePortForm : Form
    {
        private readonly int port;
        public ChangePortForm(int port = 8080)
        {
            InitializeComponent();
            this.txtPort.Text = port.ToString();
            this.port = port;
        }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port
        {
            get
            {
                return Convert.ToInt32(this.txtPort.Text);
            }
        }
        /// <summary>
        /// 端口的值是否发生变化
        /// </summary>
        public bool Changed { get => Port != port; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = this.Changed ? DialogResult.OK : DialogResult.No;
            this.Close();
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
    }
}
