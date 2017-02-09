using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public static class SlackProcessor {
		private static SlackConfig _config;

		public static void Start(SlackConfig config) {
			_config = config;
		}
	}
}