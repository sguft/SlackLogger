using System;

namespace SlackLogger.Logic {
	public interface ILogMessage {
		string Repository { get; set; }
		string LogLevel { get; set; }
		string Message { get; set; }
		Exception Exception { get; set; }
		DateTime CreatedDateUtc { get; set; }
	}
}