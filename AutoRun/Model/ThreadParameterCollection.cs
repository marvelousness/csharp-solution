using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoRun.Model
{
    internal class ThreadParameterCollection
    {
        /// <summary>
        /// 线程参数集合
        /// </summary>
        private readonly List<ThreadParameter> parameters = new List<ThreadParameter>();
        /// <summary>
        /// 新增一个新的线程回调对象
        /// </summary>
        /// <param name="callback">表示要由线程池线程执行的回调方法。</param>
        /// <param name="sender">传递到线程中的参数</param>
        public void Add(WaitCallback callback, object sender) 
        {
            Add(callback, sender, parameters.Count.ToString());
        }
        /// <summary>
        /// 
        /// 新增一个新的线程回调对象
        /// </summary>
        /// <param name="callback">表示要由线程池线程执行的回调方法。</param>
        /// <param name="sender">传递到线程中的参数</param>
        /// <param name="name">线程名称</param>
        public void Add(WaitCallback callback, object sender, string name)
        {
            ThreadParameter parameter = new ThreadParameter();
            parameter.Sender = sender;
            parameter.ThreadName = "branch-thread-" + name;
            parameters.Add(parameter);
            ThreadPool.QueueUserWorkItem(callback, parameter);
        }
        /// <summary>
        /// 线程集合的总数
        /// </summary>
        public int Count 
        {
            get
            {
                return parameters.Count;
            }
        }
        /// <summary>
        /// 所有的处理器集合
        /// </summary>
        public WaitHandle[] Handles
        {
            get
            {
                WaitHandle[] handles = new WaitHandle[parameters.Count];
                for (int i = 0; i < parameters.Count; i++)
                {
                    handles[i] = parameters[i].ManualResetEvent;
                }
                return handles;
            }
        }
    }
}
