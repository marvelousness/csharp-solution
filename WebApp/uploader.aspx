<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploader.aspx.cs" Inherits="WebApp.Uploader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <style>
        #FileUploader, #Btn {
            display:none;
        }
        .container {
            display:flex;
        }
        .container .uploader {
            width: 120px;
        }
        .container .uploader label span {
            display:block;
            width: 50px;
            height: 50px;
            line-height: 50px;
            background-color: #ECECEC;
            text-align: center;
            border: 1px solid #CCC;
        }
        .container #LabelTips {
            height: 20px;
            line-height: 20px;
            color: #CCC;
        }
        .container img {
            max-width: 200px;
            max-height: 200px;
        }
    </style>
    <form runat="server">
        <div class="container">
            <div class="uploader">
                <label>
                    <span>上传</span>
                    <asp:FileUpload ID="FileUploader" runat="server" Width="0" Height="0" />
                    <asp:Button ID="Btn" runat="server" Text="上传" Width="54px" OnClick="Btn_Click"  />
                </label>
                <asp:Label ID="LabelTips" Text="" runat="server" />
            </div>
            <asp:Image runat="server" ID="Img"  />
        </div>
    </form>
    <script>
        FileUploader.onchange = function () {
            Btn.click();
        }
    </script>
</body>
</html>
