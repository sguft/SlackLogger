using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class MessageFilter {
		public static bool ShouldProcess(ILogMessage message) {
			return true;
		}
	}
}