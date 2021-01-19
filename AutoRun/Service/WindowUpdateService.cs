using AutoRun.Model;
using System;
using System.ServiceProcess;
using System.Threading;

namespace AutoRun.Service
{
    /// <summary>
    /// window 自动更新的服务
    /// </summary>
    internal class WindowUpdateService
    {
        // [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        // public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        // [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        // public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private static readonly LogWirter wirter = new LogWirter();

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="_interval">自动检测的时间</param>
        internal static void stop(object sender)
        {
            if (!(sender is ThreadParameter))
            {
                return;
            }
            ThreadParameter parameter = (ThreadParameter)sender;
            Thread.CurrentThread.Name = parameter.ThreadName;
            Thread.CurrentThread.IsBackground = true;

            int interval = 1000;
            if (parameter.Sender != null && parameter.Sender is Int32)
            {
                interval = Convert.ToInt32(parameter.Sender);
            }
            if (interval < 10)
            {
                interval = 1000;
            }

            Console.WriteLine(Thread.CurrentThread.Name + " is running, thread parameter is " + interval);
            while (true)
            {
                using (ServiceController controller = new ServiceController("wuauserv"))
                {
                    if (controller.Status != ServiceControllerStatus.Stopped)
                    {
                        if (controller.CanStop)
                        {
                            try
                            {
                                controller.Stop();
                            }
                            catch (Exception e)
                            {
                                wirter.LogEvent("停止Window Update服务出现异常：" + e.Message);
                            }
                        }
                        else
                        {
                            wirter.LogEvent("无法停止Window Update, 请手动尝试!");
                            // Environment.Exit(0);
                        }
                        Thread.Sleep(3000);
                    }
                    if (interval > 0)
                    {
                        Thread.Sleep(interval);
                    }
                }
            }
        }
    }
}
