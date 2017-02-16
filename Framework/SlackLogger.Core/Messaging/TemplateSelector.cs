using System.Collections.Concurrent;

namespace SlackLogger.Core {
    internal static class TemplateSelector {
		public static MessageTemplate GetTemplate(MessageInclude include) {
            return TemplateRepository.GetTemplate(include.TemplateFile);			
		}
	}
}