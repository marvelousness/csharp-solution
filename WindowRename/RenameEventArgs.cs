using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowRename
{
    class RenameEventArgs
    {
        /// <summary>
        /// 事件状态
        /// </summary>
        public RenameEventStatus status = RenameEventStatus.Readied;
        /// <summary>
        /// 需要携带的标记
        /// </summary>
        public object tag;
        /// <summary>
        /// 索引
        /// </summary>
        public int index;
        /// <summary>
        /// 异常信息
        /// </summary>
        public string exception;
    }
}