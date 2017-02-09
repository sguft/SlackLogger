using System;
using log4net;
using log4net.Config;
using System.Configuration;
using SlackLogger.Client;

namespace SlackLogger.ConsoleTest {
	public class Program {
		public static readonly ILog Log = LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args) {
			XmlConfigurator.Configure();
			LogTestOutput();
			SendTestMessage();
			Console.ReadLine();
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