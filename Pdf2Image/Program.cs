using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Pdf2Image
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 测试是否能够将图片写入到磁盘
            if(false) {
                string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "test.gif";
                int width = 200, height = 200;
                using (Bitmap img = new Bitmap(width, height))
                {
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.Clear(Color.White);//绘画背景颜色
                        g.DrawRectangle(Pens.DarkGray, 0, 0, width - 1, height - 1);//绘画边框
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            //将图片 保存到内存流中
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            //将内存流 里的 数据  转成 byte 数组 返回
                        }
                    }
                    img.Save(outputPath, ImageFormat.Gif);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF 文件|*.pdf";
            dialog.Multiselect = true;
            dialog.Title = "选择PDF文件";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] filenames = dialog.FileNames;
                foreach (string filename in filenames)
                {
                    FileInfo file = new FileInfo(filename);
                    if (!file.Exists)
                    {
                        continue;
                    }
                    Core.PdfToPng(filename, file.DirectoryName, file.Name.Replace(file.Extension, ""), 1, 2, ImageFormat.Png, 36);
                }
            }
        }
    }
}
