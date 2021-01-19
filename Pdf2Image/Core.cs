using O2S.Components.PDFRender4NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pdf2Image
{
    class Core
    {
        /// <summary>
        /// 将PDF转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageOutputPath">图片输出路径</param>
        /// <param name="imageName">生成图片的名字</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        public static void PdfToPng(string pdfInputPath, string imageOutputPath, string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, int definition)
        {
            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }
            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }

            using (PDFFile pdfFile = PDFFile.Open(pdfInputPath))
            {
                bool onlyOnePage = pdfFile.PageCount == 1;
                if (endPageNum > pdfFile.PageCount)
                {
                    endPageNum = pdfFile.PageCount;
                }

                // start to convert each page
                for (int i = startPageNum; i <= endPageNum; i++)
                {
                    using (Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * definition))
                    {
                        string outputPath = imageOutputPath + Path.DirectorySeparatorChar + imageName;
                        if (!onlyOnePage) 
                        {
                            outputPath += i.ToString();
                        }
                        outputPath += "." + imageFormat.ToString();

                        Console.WriteLine("output path :" + outputPath);
                        pageImage.Save(outputPath, imageFormat);
                        pageImage.Dispose();
                    }
                }
                // pdfFile.Dispose();
            }

        }
    }
}
