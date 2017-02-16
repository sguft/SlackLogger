namespace SlackLogger.Core {
	public class SlackMessageProcessor {
		private SlackClient _client;

		public SlackMessageProcessor(SlackClient client) {
			_client = client;
        }

		public void ProcessMessage(object value) {
			foreach (MessageInclude include in MessageConfig.Includes) {
				if (MessageFilter.ShouldProcess(include, value)) {
					MessageTemplate template = TemplateSelector.GetTemplate(include);
					string chatMessage = TemplateCompiler.Compile(template, value);
					_client.Send(chatMessage).Wait();
					return;
				}
			}
		}
	}
}