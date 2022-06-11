using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class index : App_Code.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            h1.InnerText = "您好！" +  this.UserName;
        }
    }
}