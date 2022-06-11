using System;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;
using WebApp.Model;

namespace WebApp.App_Code
{
    public class InterceptorModule : IHttpModule, IRequiresSessionState
    {

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(Context_AcquireRequestState);
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = sender is HttpApplication ? sender as HttpApplication : null;
            if (application == null)
                return;
            string path = application.Request.Path;
            string method = application.Request.HttpMethod;
            Debug.WriteLine(string.Format("[{0}] {1}", method, path));
            if (path.StartsWith("/category") || path.StartsWith("/upload") || path.StartsWith("/statics") || path.EndsWith("/login.html") || path.EndsWith("/login.aspx") || path.EndsWith("/login.ashx") || path.EndsWith("/logout") || path.EndsWith("/login"))
            {
                return;
            }
            if ("/".Equals(path))
            {
                application.Response.Redirect("/index.aspx");
                return;
            }
            bool logged = application.Context.Session != null && application.Context.Session[Constant.SK] != null;
            if (!logged)
            {
                application.Response.Redirect("/login.aspx?from=interceptor&r=" + new Random().Next());
            }
        }
    }
}