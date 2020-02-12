using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class ConsoleLogger : ILogger
    {
        public LoggerResponse LogMessage(Message message)
        {
            try
            {
                SetConsoleColor(message);
                Console.WriteLine(message.Content);
                return new LoggerResponse(LogType.Console);
            }
            catch (Exception ex)
            {
                return new LoggerResponse(LogType.Console, ex);
            }
        }

        private static void SetConsoleColor(Message message)
        {
            switch (message.MessageType)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}