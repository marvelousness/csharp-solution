using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WifiConnector.Math;

namespace WifiConnector
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Arrangement arrangement = new Arrangement(32, 128, 8);
            //Arrangement arrangement = new Arrangement(2, 7, 3);
            //foreach (int[] item in arrangement)
            //{
            //    foreach (int i in item)
            //    {
            //        Console.Write(i + " ");
            //    }
            //    Console.WriteLine();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
