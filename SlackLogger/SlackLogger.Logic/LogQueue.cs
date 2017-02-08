using log4net.Core;
using System.Collections.Concurrent;

namespace SlackLogger.Logic {
    public static class LogQueue {
        private static ConcurrentQueue<LoggingEvent> _logQueue = new ConcurrentQueue<LoggingEvent>();

        public static void Enqueue(LoggingEvent logEvent) {
            _logQueue.Enqueue(logEvent);
        }

        public static bool TryDequeue(out LoggingEvent logEvent) {
            return _logQueue.TryDequeue(out logEvent);
        }
    }
}