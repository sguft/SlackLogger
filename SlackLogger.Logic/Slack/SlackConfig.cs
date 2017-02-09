using System.Collections.Concurrent;
using System.Configuration;

namespace SlackLogger.Logic {
	public class SlackConfig {
		public string WebhookUrl { get; set; }

		public static SlackConfig FromAppConfig() {
			SlackConfig config = new SlackConfig();
			config.WebhookUrl = ConfigurationManager.AppSettings["Slack.WebhookUrl"];
			return config;
		}
	}
}