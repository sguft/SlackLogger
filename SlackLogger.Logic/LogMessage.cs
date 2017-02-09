using System;

namespace SlackLogger.Logic {
	public class LogMessage : ILogMessage {
		public string Repository { get; set; }
		public string LogLevel { get; set; }
		public string Message { get; set; }
		public Exception Exception { get; set; }
		public DateTime CreatedDateUtc { get; set; }
	}
}