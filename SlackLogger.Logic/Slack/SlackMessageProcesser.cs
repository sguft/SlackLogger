using SlackLogger.Client;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace SlackLogger.Logic {
	public class SlackMessageProcessor {
		private SlackClient _client;

		public SlackMessageProcessor(SlackClient client) {
			_client = client;	
		}

		public void ProcessMessage(ILogMessage message) {
			if (MessageFilter.ShouldProcess(message)) {
				MessageTemplate template = TemplateSelector.GetTemplate(message);
				string chatMessage = TemplateCompiler.Compile(template, message);
				_client.Send(chatMessage).Wait();
			}
		}
	}
}