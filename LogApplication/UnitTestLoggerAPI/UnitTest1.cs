using NUnit.Framework;
using WebLogApi.Model;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConsoleLogger()
        {
            ConsoleLogger logger = new ConsoleLogger();
            LoggerResponse loggerResponse = logger.LogMessage(new Message() { Content = "Test Message", MessageType = MessageType.Error });
            Assert.AreEqual(loggerResponse.Message, "The message was save");
            Assert.AreEqual(loggerResponse.Succes, true);
            Assert.AreEqual(loggerResponse.LogType, LogType.Console);
        }
        [Test]
        public void TestFileLogger()
        {
            FileLogger logger = new FileLogger();
            LoggerResponse loggerResponse = logger.LogMessage(new Message() { Content = "Test Message", MessageType = MessageType.Error });
            Assert.AreEqual(loggerResponse.Message, "The message was save");
            Assert.AreEqual(loggerResponse.Succes, true);
            Assert.AreEqual(loggerResponse.LogType, LogType.File);
        }
        [Test]
        public void TestDataBaseLogger()
        {
            DataBaseLogger logger = new DataBaseLogger();
            LoggerResponse loggerResponse = logger.LogMessage(new Message() { Content = "Test Message", MessageType = MessageType.Error });
            Assert.AreEqual(loggerResponse.Message, "The message was save");
            Assert.AreEqual(loggerResponse.Succes, true);
            Assert.AreEqual(loggerResponse.LogType, LogType.DataBase);
        }
    }
}