<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp.login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>用户登录</title>
        <link rel="stylesheet" href="statics/css/login.css" />
        <script type="text/javascript" src="statics/js/jquery-3.5.1.min.js"></script>
        <script type="text/javascript" src="statics/js/login.js"></script>
    </head>
    <body>
        <h1>用户登录</h1>
        <div class="container">
            <form class="form" runat="server">
                <div>
                    <asp:TextBox ID="username" runat="server" placeholder="用户名：" autocomplete="off"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="密码：" autocomplete="off"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn" runat="server" Text="登录" OnClick="Btn_Click" />
                    <a href="/">前往首页</a>
                </div>
            </form>
            <form class="form" id="f">
                <div>
                    <input type="text" name="username" autocomplete="off" />
                </div>
                <div>
                    <input type="password" name="password" autocomplete="off" />
                </div>
                <div>
                    <button type="button">登录</button>
                    <a href="index.aspx">前往首页</a>
                    <a href="login.html">前往单独的登录页</a>
                </div>
            </form>
        </div>
    </body>
</html>
