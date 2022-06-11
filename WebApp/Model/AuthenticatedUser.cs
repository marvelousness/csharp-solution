using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApp.Model
{
    /// <summary>
    /// 已认证的用户
    /// </summary>
    public class AuthenticatedUser
    {
        public string Name { get; set; }

        /// <summary>
        /// 认证用户
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public static AuthenticatedUser Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Parameters not provided");
            }

            DbEntities entities = new DbEntities();
            Debug.WriteLine("总数：" + entities.user.Count());
            if (entities.user.Any(u => u.username.Equals(username) && u.password.Equals(password)))
            {
                Debug.WriteLine("存在该用户：" + username);
            }
            user user = entities.user.Where(u => u.username.Equals(username) && u.password.Equals(password)).FirstOrDefault();

            return user != null ? new AuthenticatedUser
            {
                Name = user.nickname
            } : null;
        }
    }
}