using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class MessageFilter {
		public static bool ShouldProcess(MessageInclude include, ILogMessage message) {
            System.Console.WriteLine("LogLevel: " + message.LogLevel);
            return include.LogLevelPattern.IsMatch(message.LogLevel) && include.MessagePattern.IsMatch(message.Message);
		}
	}
}