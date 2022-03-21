using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowRename
{
    internal class Renamer
    {
        public event RenameEventHandler Finish;
        public void Replace(string oldname, string newname, params string[] names) 
        {
            if (String.IsNullOrEmpty(oldname)) 
            {
                oldname = "";
            }
            if (String.IsNullOrEmpty(newname))
            {
                newname = "";
            }
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                FileInfo file = new FileInfo(name);
                RenameEventArgs args = new RenameEventArgs();
                args.tag = name;
                args.index = i;
                if (!file.Exists)
                {
                    args.status = RenameEventStatus.FileNotFound;
                    this.report(args);
                    continue;
                }
                if (oldname.Length < 1) 
                {
                    args.status = RenameEventStatus.Canceled;
                    args.exception = "未提供原名称";
                    this.report(args);
                    continue;
                }
                string destName = Regex.Replace(file.Name,oldname, newname);
                destName = file.DirectoryName + Path.DirectorySeparatorChar + destName;
                if (file.FullName.Equals(destName))
                {
                    args.status = RenameEventStatus.Canceled;
                    args.exception = "新名称与原名称一致";
                    this.report(args);
                    continue;
                }
                FileInfo destFile = new FileInfo(destName);

                args.status = RenameEventStatus.Readied;
                this.report(args);
                try
                {
                    if (!Directory.Exists(destFile.DirectoryName))
                    {
                        Directory.CreateDirectory(destFile.DirectoryName);
                    }
                    Directory.Move(file.FullName, destName);
                    args.status = RenameEventStatus.Completed;
                    this.report(args);
                }
                catch (Exception e)
                {
                    args.status = RenameEventStatus.Error;
                    args.exception = e.Message;
                    this.report(args);
                }
            }
        }
        public void Index(string prefix = "", string suffix = "", params string[] names)
        {
            int count = names.Length;
            int length = ("" + count).Length;
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                FileInfo file = new FileInfo(name);
                RenameEventArgs args = new RenameEventArgs();
                args.tag = name;
                args.index = i;
                if (!file.Exists)
                {
                    args.status = RenameEventStatus.FileNotFound;
                    this.report(args);
                    continue;
                }
                string num = ("" + i);
                while (num.Length < length)
                {
                    num = "0" + num;
                }
                string destName = file.DirectoryName + Path.DirectorySeparatorChar + prefix + num + suffix + file.Name;
                FileInfo destFile = new FileInfo(destName);

                args.status = RenameEventStatus.Readied;
                this.report(args);
                try
                {
                    if (!Directory.Exists(destFile.DirectoryName)) 
                    {
                        Directory.CreateDirectory(destFile.DirectoryName);
                    }
                    Directory.Move(file.FullName, destName);
                    args.status = RenameEventStatus.Completed;
                    this.report(args);
                }
                catch (Exception e)
                {
                    args.status = RenameEventStatus.Error;
                    args.exception = e.Message;
                    this.report(args);
                }
            }
        }
        private void report(RenameEventArgs args) 
        {
            if (Finish != null)
            {
                Finish(this, args);
            }
        }
    }
}
