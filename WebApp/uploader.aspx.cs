using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Uploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.FileUploader.FileName))
            {
                this.LabelTips.Text = "上传文件名称为空";
                return;
            }

            bool fileIsValid = false;
            //如果确认了上传文件，则判断文件类型是否符合要求
            if (this.FileUploader.HasFile)
            {
                // 上传文件的大小
                int size = FileUploader.PostedFile.ContentLength;
                //获取上传文件的后缀
                string name = this.FileUploader.FileName;
                String suffix = Path.GetExtension(name);
                String[] suffixs = { ".jpg", ".bmp", ".png" };
                //判断文件类型是否符合要求
                for (int i = 0; i < suffixs.Length; i++)
                {
                    if (suffix.ToLower().Equals(suffixs[i]))
                    {
                        fileIsValid = true;
                    }
                    //如果文件类型符合要求,
                    // 调用SaveAs方法实现上传,并显示相关信息
                    if (fileIsValid == true)
                    {
                        //上传文件是否大于10M
                        if (size > (10 * 1024 * 1024))
                        {
                            this.LabelTips.Text = "上传文件过大";
                            return;
                        }
                        string path = Server.MapPath("~/upload/");
                        this.Img.ImageUrl = "~/upload/" + name;
                        try
                        {
                            this.FileUploader.SaveAs(path + name);
                            this.LabelTips.Text = "文件上传成功";
                        }
                        catch (Exception ex)
                        {
                            this.LabelTips.Text =
                                "文件上传失败，原因是：" + ex.Message;
                        }
                    }
                    else
                    {
                        this.LabelTips.Text =
                            "只能够上传后缀为.gif,.jpg,.bmp,.png的文件";
                    }
                }
            }
        }
    }
}