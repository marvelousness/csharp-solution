using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Model;

namespace WebApp.App_Code
{
    /// <summary>
    /// WebPage 的摘要说明
    /// </summary>
    public class WebPage : System.Web.UI.Page
    {
        public new AuthenticatedUser User
        {
            get
            {
                object o = this.Session[Constant.SK];
                // return o is App_Code.AuthenticatedUser ? o as App_Code.AuthenticatedUser : null;
                return o != null ? (AuthenticatedUser)o : null;
            }
        }

        public string UserName
        {
            get
            {
                return this.User != null ? this.User.Name : "";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.User != null;
            }
        }

        public bool IsUnAuthenticated
        {
            get
            {
                return !this.IsAuthenticated;
            }
        }

        public void Login(string username) 
        {
            AuthenticatedUser user = new AuthenticatedUser
            {
                Name = username
            };
            this.Session.Add("SDATA", user);
        }
    }
}