using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using IMS.Common.Enums;

namespace IMS.Common
{
    /// <summary>
    /// LoggingUtils provides methods to log message to system's event viewer.
    /// </summary>

    public static class LoggingUtil
    {
        public static void LogException(Exception exception, ErrorLevel errorLevel, string urlRef = null)
        {
            StringBuilder sbMessage = new StringBuilder();

            sbMessage.AppendFormat("RDC-FAH-MVC Message Logging\n Message Level: {0}\n", errorLevel.ToString());

            // If any custom data was added to the exception...
            //Contains api method url, etc to excatly know where the problem occured.
            if (exception.Data.Keys.Count > 0)
            {
                sbMessage.Append("\nData:\n");
                foreach (System.Collections.DictionaryEntry dataItem in exception.Data)
                {
                    sbMessage.AppendFormat(" {0} = {1}\n", dataItem.Key, dataItem.Value);
                }
            }

            if (exception.InnerException != null)
            {
                sbMessage.AppendFormat("\nInner Exception:\n Type : {0}\n", exception.InnerException.GetType());
                sbMessage.AppendFormat(" Message : {0}\n", exception.InnerException.Message);
                if (!String.IsNullOrEmpty(exception.InnerException.StackTrace))
                {
                    sbMessage.AppendFormat(" Stack Trace : {0}\n", exception.InnerException.StackTrace);
                }
                sbMessage.Append('\n');
            }

            sbMessage.AppendFormat("\nException:\n Type : {0}\n", exception.GetType().FullName);

            sbMessage.AppendFormat(" Message : {0}\n", exception.Message);

            if (!String.IsNullOrEmpty(exception.Source))
            {
                sbMessage.AppendFormat(" Source : {0}\n", exception.Source);
            }

            sbMessage.AppendFormat(" Stack Trace : {0}\n",
                !String.IsNullOrEmpty(exception.StackTrace) ? exception.StackTrace : (new StackTrace(false)).ToString());

            if (exception.TargetSite != null)
            {
                sbMessage.AppendFormat(" Target Site : {0}\n", exception.TargetSite);
            }

            if (urlRef != null)
            {
                sbMessage.AppendFormat(" URL: {0}\n", urlRef);
            }

            WriteLogEntry(
                sbMessage.ToString(),
                errorLevel,
                "ApplicationEventLogName"
                );
        }

        /// <summary>
        /// Write log entry to event viewer
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorLevel"></param>
        /// <param name="logName"></param>
        /// <param name="eventSource"></param>
        public static void WriteLogEntry(string message, ErrorLevel errorLevel, string logName, string eventSource = null)
        {
            const int MESSAGE_MAX_LENGTH = 32765;
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(logName))
                return;

            //below length check is to avoid error when logging to event viewer. There is a limit and if that limit is crossed
            //results in blank screen.
            message = message.Length > MESSAGE_MAX_LENGTH ? message.Substring(0, MESSAGE_MAX_LENGTH) : message;

            EventLogEntryType eventLogMsgType;
            switch (errorLevel)
            {
                case ErrorLevel.Information:
                    eventLogMsgType = EventLogEntryType.Information;
                    break;
                case ErrorLevel.Warning:
                    eventLogMsgType = EventLogEntryType.Warning;
                    break;
                    
                default:
                    eventLogMsgType = EventLogEntryType.Error;
                    break;
            }

            // If no source was specified, use the default handling behavior through
            // the move utilities.
            if (string.IsNullOrEmpty(eventSource))
            {
                // Send Exception Message to DB
                
            }
            else
            {
                using (var log = new EventLog(logName) {Source = eventSource, EnableRaisingEvents = true})
                    log.WriteEntry(message, eventLogMsgType, 0, 0, null);
            }
        }
        
    }
}