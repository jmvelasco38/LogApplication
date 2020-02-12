using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class LoggerFactory
    {
        public static ILogger CreateLogger(LogType logType)
        {
            ILogger logger;
            switch(logType)
            {
                case LogType.Console:
                    logger = new ConsoleLogger();
                    break;
                case LogType.DataBase:
                    logger = new DataBaseLogger();
                    break;
                case LogType.File:
                    logger = new FileLogger();
                    break;
                default:
                    logger = null;
                    break;
            }
            return logger;
        }
    }
}