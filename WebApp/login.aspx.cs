using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.App_Code;
using WebApp.Model;

namespace WebApp
{
    public partial class login : App_Code.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            string u = this.username.Text;
            string p = this.password.Text;
            AuthenticatedUser user = AuthenticatedUser.Authenticate(u, p);
            if (user != null)
            {
                this.Session[Constant.SK] = user;
                Debug.WriteLine("已完成登录操作：" + user.Name);
                this.Response.Redirect("/");
            }
        }
    }
}