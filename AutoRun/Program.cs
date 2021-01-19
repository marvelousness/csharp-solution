using AutoRun.Model;
using AutoRun.Service;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AutoRun
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Title = "WAHAHA";
            // IntPtr intptr = FindWindow("ConsoleWindowClass", "WAHAHA");
            // if (intptr != IntPtr.Zero) ShowWindow(intptr, 0);//隐藏这个窗口

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 默认一个小时检测一次，且不允许低于1s
            int interval = 3600000;
            if (args != null && args.Length > 0)
            {
                try
                {
                    interval = Convert.ToInt32(args[0]);
                }
                catch (Exception) { }
            }
            interval = interval < 1000 ? 3600000 : interval;

            ThreadParameterCollection collection = new ThreadParameterCollection();

            // 关闭系统自动更新服务
            collection.Add(WindowUpdateService.stop, interval, "WindowUpdateService");

            // 关闭 BeyondCompare4 的授权检测
            collection.Add(BeyondCompare4.detect, 86400000, "BeyondCompare4");

            Console.WriteLine("I`m main thread begin");
            WaitHandle.WaitAll(collection.Handles);
            Console.WriteLine("I`m main thread finish");
        }

    }
}