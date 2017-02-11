using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class TemplateSelector {
		public static MessageTemplate GetTemplate(MessageInclude include) {
            return TemplateRepository.GetTemplate(include.TemplateFile);			
		}
	}
}