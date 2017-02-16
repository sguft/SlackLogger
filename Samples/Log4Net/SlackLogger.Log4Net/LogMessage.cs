using System;

namespace SlackLogger.Log4Net {
	public class LogMessage {
		public string Repository { get; set; }
		public string LogLevel { get; set; }
		public string Message { get; set; }
		public Exception Exception { get; set; }
		public DateTime CreatedDateUtc { get; set; }
        public DateTime CreatedDateLocal { get; set; }
        public long TimestampUtc { get; set; }
        public long TimestampLocal { get; set; }
    }
}