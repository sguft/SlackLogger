using System;
using System.Diagnostics;
using System.Threading;

namespace SlackLogger.Core {
    public static class SlackProcessor {
		private static SlackConfig _config;
		private static Thread _thread;

		static SlackProcessor() {
			_thread = new Thread(Execute);
			_thread.IsBackground = true;
			_thread.Start();
		}

		public static void Start(SlackConfig config) {
            ValidateConfiguration(config);
			_config = config;
            MessageConfig.Init(config);
            TemplateRepository.Init(config);
        }

        public static void Enqueue(object value) {
            MessageQueue.Enqueue(value);
        }

        private static void ValidateConfiguration(SlackConfig config) {
            if (string.IsNullOrWhiteSpace(config.WebhookUrl)) {
                throw new ArgumentException("Invalid Configuration: Please provide a valid url for WebhookUrl");
            }
            if (!Uri.IsWellFormedUriString(config.WebhookUrl, UriKind.Absolute)) {
                throw new ArgumentException($"Invalid Configuration: The value provided for WebhookUrl is not a valid url: '{config.WebhookUrl}'");
            }
            if (string.IsNullOrWhiteSpace(config.TemplateRootFolder)) {
                throw new ArgumentException("Invalid Configuration: Please provide a valid directory path for TemplateRootFolder");
            }
            if (!Uri.IsWellFormedUriString(config.WebhookUrl, UriKind.Absolute)) {
                throw new ArgumentException($"Invalid Configuration: The directory path specified in TemplateRootFolder was not found: '{config.TemplateRootFolder}'");
            }
        }

        private static void Execute() {
			while (true) {
				try {
					ProcessQueue();
				}
				catch (Exception ex) {
                    Console.WriteLine(ex);
					Debug.WriteLine(ex);
				}
				Thread.Sleep(100);
			}
		}

		private static void ProcessQueue() {
			object message;
			while (MessageQueue.TryDequeue(out message)) {
				SlackClient client = new SlackClient(_config.WebhookUrl);
				SlackMessageProcessor messageProcessor = new SlackMessageProcessor(client);
				messageProcessor.ProcessMessage(message);
			}
		}
	}
}