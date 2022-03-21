using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WifiConnector
{
    public partial class FormPasswordInput : Form
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public FormPasswordInput()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }
            if (e.KeyChar != 13)
            {
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.error.SetError(this.txtPassword, "请输入密码");
                return;
            }
            if (this.txtPassword.Text.Length < 8)
            {
                this.error.SetError(this.txtPassword, "密码长度不足八位");
                return;
            }
            this.Password = this.txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
