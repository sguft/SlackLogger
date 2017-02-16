using System;
using log4net;
using log4net.Config;
using System.Threading.Tasks;
using System.Threading;
using SlackLogger.Core;
using System.Configuration;

namespace SlackLogger.ConsoleTest {
    public class Program {
		public static readonly ILog Log = LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args) {
            XmlConfigurator.Configure();
			StartProcessor();
            LogTestOutput();
            Console.ReadLine();
		}

		private static void StartProcessor() {
            SlackConfig config = new SlackConfig();
            config.WebhookUrl = ConfigurationManager.AppSettings["Slack.WebhookUrl"];
            config.TemplateRootFolder = "./Configuration";
            SlackProcessor.Start(config);
		}

        public static SlackConfig FromAppConfig() {
            SlackConfig config = new SlackConfig();
            
            return config;
        }

        private static void LogTestOutput() {
            Task.Run(() => {
                while (true) {
                    SendException();
                    Thread.Sleep(7000);
                    SendWarning();
                    Thread.Sleep(7000);
				}
            });
		}

        private static void SendException() {
            try {
                throw new NullReferenceException();
            }
            catch (Exception ex) {
                Log.Error("Bad Error Happened", ex);
            }
            Console.WriteLine("Error Sent");
        }

        private static void SendWarning() {
            Log.Warn("Not so bad thing happened");
            Console.WriteLine("Warning Sent");
        }
	}
}