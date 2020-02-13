using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class FileLogger : ILogger
    {
        public LoggerResponse LogMessage(Message message)
        {
            try
            {
                using(StreamWriter file = CheckFile())
                {
                    file.WriteLine(message.Content);
                }
                return new LoggerResponse(LogType.File);

            }catch(Exception ex)
            {
                return new LoggerResponse(LogType.File, ex);
            }
        }

        private StreamWriter CheckFile()
        {
            string fileName = string.Format("{0}{1}{2}.txt", ConfigurationManager.AppSettings["LogFileDirectory"].ToString(), ConfigurationManager.AppSettings["LogFileName"].ToString(), DateTime.Now.ToShortDateString());
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            return new StreamWriter(fileName);
        }
    }
}