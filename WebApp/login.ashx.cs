using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebApp.App_Code;
using WebApp.Model;

namespace WebApp
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];

            AuthenticatedUser user = AuthenticatedUser.Authenticate(username, password);
            if (context.Session == null)
            {
                context.Response.Write("Session is null");
                return;
            }
            context.Session[Constant.SK] = user;
            context.Response.Write(user != null ? "OK" : "NO");
        }
    }
}