using System;
using log4net;
using log4net.Config;

namespace SlackLogger.ConsoleTest {
    public class Program {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args) {
            XmlConfigurator.Configure();
            LogTestOutput();
            Console.ReadLine();
        }

        private static void LogTestOutput() {
            Log.Info("Running test");
        }
    }
}