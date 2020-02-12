using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class LoggerResponse
    {
        public bool Succes { get; set; }

        public string Message { get; set; }

        public LogType LogType { get; set; }

        public LoggerResponse(LogType logType, Exception exception)
        {
            Message = string.Format("Exception: {0}, StackTrace: {1}", exception.Message, exception.StackTrace);
            Succes = false;
            LogType = logType;
        }

        public LoggerResponse(LogType logType)
        {
            Message = "The message was save";
            Succes = true;
            LogType = logType;
        }
    }
}