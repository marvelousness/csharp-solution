using AutoRun.Model;
using System;
using System.IO;
using System.Threading;

namespace AutoRun.Service
{
    internal class BeyondCompare4
    {
        private static readonly LogWirter wirter = new LogWirter();
        /// <summary>
        /// 检测 BeyondCompare4 的授权文件
        /// </summary>
        internal static void detect(object sender)
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
                string[] dirs = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Scooter Software");
                foreach (string dir in dirs)
                {
                    Rename(Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories));
                    Rename(Directory.GetFiles(dir, "*.bak", SearchOption.AllDirectories));
                }
                if (interval > 0)
                {
                    Thread.Sleep(interval);
                }
            }
        }

        private static void Rename(string[] files)
        {
            foreach (string file in files)
            {
                string dest = file + ".deprecated";
                try
                {
                    if (!File.Exists(dest))
                    {
                        File.Delete(dest);
                    }
                    File.Move(file, dest);
                }
                catch (Exception e)
                {
                    wirter.LogEvent("重命名出错，目标文件： " + file + "，错误信息：" + e.Message);
                }
            }
        }
    }
}
