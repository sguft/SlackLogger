using System;
using log4net;
using log4net.Config;
using System.Configuration;
using SlackLogger.Client;
using SlackLogger.Logic;

namespace SlackLogger.ConsoleTest {
	public class Program {
		public static readonly ILog Log = LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args) {
			XmlConfigurator.Configure();
			LogTestOutput();
			SendTestMessage();
			StartProcessor();
			Console.ReadLine();
		}

		private static void StartProcessor() {
			SlackProcessor.Start(SlackConfig.FromAppConfig());
		}

		private static void SendTestMessage() {
			string webhookUrl = ConfigurationManager.AppSettings["Slack.WebhookUrl"];
			Console.WriteLine(webhookUrl);
			SlackClient client = new SlackClient(webhookUrl);
			client.Send("Hello World").Wait();
		}

		private static void LogTestOutput() {
			Log.Info("Running test");
		}
	}
}