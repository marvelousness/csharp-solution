﻿using System;
using System.Web;
using System.Web.SessionState;
using WebApp.Model;

namespace WebApp.App_Code.Handler
{
    public class LogoutHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler 成员

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session != null)
            {
                context.Session.Remove(Constant.SK);
                context.Response.Redirect("/");
            }
        }

        #endregion
    }
}
