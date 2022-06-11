using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Web.Script.Serialization;

namespace WebApp.App_Code.Handler
{
    public class CategoryHandler : IHttpHandler
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
            DbEntities entities = new DbEntities();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            // 根据访问路径的后缀决定做出什么动作
            string path = context.Request.Path;
            if (context.Request.HttpMethod.Equals(WebRequestMethods.Http.Post))
            {
                if (path.EndsWith("add"))
                {
                    //新增
                    string name = context.Request.Form["name"]; 
                    category c = new category();
                    c.name = name;
                    entities.category.Add(c);
                    entities.SaveChanges();
                }
                else if (path.EndsWith("adds"))
                {
                    // 批量新增
                    Stream stream = context.Request.InputStream;
                    StreamReader reader = new StreamReader(stream);
                    List<category> cs = serializer.Deserialize<List<category>>(reader.ReadToEnd());
                    foreach (category c in cs)
                    {
                        Debug.WriteLine(c);
                        // 如果不存在的情况下，考虑新增
                        if (!entities.category.Any(a => a.Id == c.Id))
                        {
                            entities.category.Add(c);
                        }
                        entities.SaveChanges();
                    }
                }
                else if (path.EndsWith("delete"))
                {
                    // 处理删除
                    category c = new category();
                    c.Id = Convert.ToInt32(context.Request.Params["id"]);
                    if (entities.category.Any(a => a.Id == c.Id))
                    {
                        entities.category.Attach(c);
                        entities.category.Remove(c);
                        entities.SaveChanges();
                    }
                }
            }

            IEnumerable<category> categories = entities.category.Where(a => a.Id > 0);
            context.Response.ContentType = "application/json";
            context.Response.Write(serializer.Serialize(categories));
        }
        #endregion
    }
}