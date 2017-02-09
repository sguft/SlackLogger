using SlackLogger.Client;
using System;
using System.Diagnostics;
using System.Threading;

namespace SlackLogger.Logic {
	public static class SlackProcessor {
		private static SlackConfig _config;
		private static Thread _thread;

		static SlackProcessor() {
			_thread = new Thread(Execute);
			_thread.IsBackground = true;
			_thread.Start();
		}

		public static void Start(SlackConfig config) {
			_config = config;
		}

		private static void Execute() {
			while (true) {
				try {
					ProcessQueue();
				}
				catch (Exception ex) {
					Debug.WriteLine(ex);
				}
				Thread.Sleep(100);
			}
		}

		private static void ProcessQueue() {
			ILogMessage message;
			while (LogQueue.TryDequeue(out message)) {
				SlackClient client = new SlackClient(_config.WebhookUrl);
				SlackMessageProcessor messageProcessor = new SlackMessageProcessor(client);
				messageProcessor.ProcessMessage(message);
			}
		}
	}
}