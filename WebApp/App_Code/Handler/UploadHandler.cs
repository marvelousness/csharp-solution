using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApp.App_Code.Handler
{
    public class UploadHandler : IHttpHandler
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
            List<string> ps = new List<string>();
            string path = context.Server.MapPath("~/upload/");
            HttpRequest request = context.Request;
            for (int i = 0; i < request.Files.AllKeys.Length; i++)
            {
                string key = request.Files.AllKeys[i];
                HttpPostedFile file = request.Files[key];
                string name = file.FileName;
                try
                {
                    string filename = path + name;
                    file.SaveAs(filename);
                    ps.Add("/upload/" + name);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("文件上传失败，原因是：" + ex.Message);
                }
            }

            if (ps.Count == 1)
            {
                // 针对多张图片，返回该图片的访问地址
                context.Response.ContentType = "text/plain";
                context.Response.Write(ps[0]);
            }
            else
            {
                // 针对多张图片，返回所有图片的访问地址
                context.Response.ContentType = "application/json;charset=utf-8";
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(ps);
                context.Response.Write(json);
            }
        }

        #endregion
    }
}
