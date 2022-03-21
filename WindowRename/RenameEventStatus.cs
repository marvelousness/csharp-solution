using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowRename
{
    enum RenameEventStatus
    {
        /// <summary>
        /// 准备就绪
        /// </summary>
        Readied,
        /// <summary>
        /// 事件已完成
        /// </summary>
        Completed,
        /// <summary>
        /// 找不到文件
        /// </summary>
        FileNotFound,
        /// <summary>
        /// 已取消
        /// </summary>
        Canceled,
        /// <summary>
        /// 出错
        /// </summary>
        Error
    }
}
