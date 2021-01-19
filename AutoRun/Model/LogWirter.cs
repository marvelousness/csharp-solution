using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AutoRun.Model
{
    /// <summary>
    /// 日志书写器
    /// </summary>
    public class LogWirter
    {
        /// <summary>
        /// 事件源名称
        /// </summary>
        private string eventSourceName;
        EventLogEntryType eventLogType;
        public LogWirter()
        {
            eventSourceName = "StopWindowUpdate";
            eventLogType = EventLogEntryType.Error;
        }

        /// <summary>
        /// 消息事件源名称
        /// </summary>
        public string EventSourceName
        {
            set { eventSourceName = value; }
        }

        /// <summary>
        /// 消息事件类型
        /// </summary>
        public EventLogEntryType EventLogType
        {
            set { eventLogType = value; }
        }

        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="message">事件内容</param>
        public void LogEvent(string message)
        {
            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, "Application");
            }
            EventLog.WriteEntry(eventSourceName, message, eventLogType);
        }

        public void LogEvent(string message, EventLogEntryType eventLogType)
        {
            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, "Application");
            }

            EventLog.WriteEntry(eventSourceName, message, eventLogType);
        }
    }
}
