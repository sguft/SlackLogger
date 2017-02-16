using System.Collections.Concurrent;

namespace SlackLogger.Core {
	public static class LogQueue {
		private static ConcurrentQueue<object> _eventQueue = new ConcurrentQueue<object>();

		public static void Enqueue(object value) {
            _eventQueue.Enqueue(value);
		}

		public static bool TryDequeue(out object value) {
			return _eventQueue.TryDequeue(out value);
		}
	}
}