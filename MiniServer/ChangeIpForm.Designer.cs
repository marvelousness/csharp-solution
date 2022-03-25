
namespace MiniServer
{
    partial class ChangeIpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeIpForm));
            this.coBoxIp = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // coBoxIp
            // 
            this.coBoxIp.FormattingEnabled = true;
            this.coBoxIp.Location = new System.Drawing.Point(28, 13);
            this.coBoxIp.Name = "coBoxIp";
            this.coBoxIp.Size = new System.Drawing.Size(256, 41);
            this.coBoxIp.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Font = new System.Drawing.Font("宋体", 16F);
            this.btnOk.Location = new System.Drawing.Point(300, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 41);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ChangeIpForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 69);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.coBoxIp);
            this.Font = new System.Drawing.Font("宋体", 16F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeIpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更换绑定的IP地址";
            this.Load += new System.EventHandler(this.ChangeIpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox coBoxIp;
        private System.Windows.Forms.Button btnOk;
    }
}