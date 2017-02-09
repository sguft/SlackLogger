using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class LogQueue {
		private static ConcurrentQueue<ILogMessage> _logQueue = new ConcurrentQueue<ILogMessage>();

		public static void Enqueue(ILogMessage message) {
			_logQueue.Enqueue(message);
		}

		public static bool TryDequeue(out ILogMessage message) {
			return _logQueue.TryDequeue(out message);
		}
	}
}