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
            foreach (MessageInclude include in MessageConfig.Includes) {
                if (MessageFilter.ShouldProcess(include, message)) {                    
                    MessageTemplate template = TemplateSelector.GetTemplate(include, message);                    
                    string chatMessage = TemplateCompiler.Compile(template, message);                    
                    _client.Send(chatMessage).Wait();
                }
			}
		}
	}
}