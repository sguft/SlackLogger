using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class TemplateSelector {
		public static MessageTemplate GetTemplate(ILogMessage message) {
			return new MessageTemplate();
		}
	}
}