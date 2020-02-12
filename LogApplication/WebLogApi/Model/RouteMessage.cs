using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class RouteMessage : IRouteMessage
    {
        private IEnumerable<ILogger> loggers;
        private IEnumerable<MessageType> messageTypes;
        public RouteMessage()
        {
            ConfigureMessageToLog();
            ConfigureListLog();
        }

        private void ConfigureMessageToLog()
        {
            List<MessageType> messages = new List<MessageType>();
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["MessageLog"]))
            {
                messages.Add(MessageType.Message);
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["WarningLog"]))
            {
                messages.Add(MessageType.Warning);
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["ErrorLog"]))
            {
                messages.Add(MessageType.Error);
            }
            messageTypes = messages;
        }

        private void ConfigureListLog()
        {
            List<ILogger> loggers = new List<ILogger>();
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["ConsoleLog"]))
            {
                loggers.Add(LoggerFactory.CreateLogger(LogType.Console));
            }
            if(Convert.ToBoolean(ConfigurationManager.AppSettings["FileLog"]))
            {
                loggers.Add(LoggerFactory.CreateLogger(LogType.File));
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["DataBaseLog"]))
            {
                loggers.Add(LoggerFactory.CreateLogger(LogType.DataBase));
            }
            this.loggers = loggers;
        }

        public IEnumerable<LoggerResponse> ManaggeMessage(Message message)
        {
            List<LoggerResponse> responses = new List<LoggerResponse>();
            foreach(ILogger logger in loggers)
            {
                if (messageTypes.Contains(message.MessageType))
                {
                    responses.Add(logger.LogMessage(message));
                }
            }
            return responses;
        }
    }
}