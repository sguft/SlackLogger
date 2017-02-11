using System;
using log4net.Appender;
using log4net.Core;
using SlackLogger.Logic;

namespace SlackLogger.Log4Net {
	public class SlackLogAppender : AppenderSkeleton {

		protected override void Append(LoggingEvent loggingEvent) {
			LogMessage message = GetMessage(loggingEvent);
			LogQueue.Enqueue(message);
			Console.WriteLine("Message: " + message.Message);
		}

		private LogMessage GetMessage(LoggingEvent loggingEvent) {
			LogMessage result = new LogMessage();
			result.Repository = loggingEvent.Repository?.Name ?? string.Empty;
			result.LogLevel = loggingEvent.Level?.DisplayName ?? string.Empty;
			result.Message = loggingEvent.RenderedMessage ?? string.Empty;
			result.Exception = loggingEvent.ExceptionObject;
			result.CreatedDateUtc = loggingEvent.TimeStampUtc;
            result.CreatedDateLocal = loggingEvent.TimeStamp;
            result.TimestampUtc = GetUnixTimestamp(result.CreatedDateUtc);
            result.TimestampLocal = GetUnixTimestamp(result.CreatedDateLocal);
            return result;
		}

        private long GetUnixTimestamp(DateTime value) {
            DateTimeOffset offset = new DateTimeOffset(value);
            return offset.ToUnixTimeSeconds();            
        }
	}
}