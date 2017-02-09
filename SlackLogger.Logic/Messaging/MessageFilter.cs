using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class MessageFilter {
		public static bool ShouldProcess(MessageInclude include, ILogMessage message) {
			return true;
		}
	}
}