using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoRun.Model
{
    /// <summary>
    /// 线程参数
    /// </summary>
    internal class ThreadParameter
    {
        /// <summary>
        /// 事件
        /// </summary>
        internal readonly ManualResetEvent ManualResetEvent = new ManualResetEvent(false);
        /// <summary>
        /// 参数
        /// </summary>
        internal object Sender;
        /// <summary>
        /// 线程名称
        /// </summary>
        internal string ThreadName;
    }
}
