using System.Collections.Concurrent;

namespace SlackLogger.Core {
	public class MessageTemplate {
        public string Content { get; set; }

        public MessageTemplate(string content) {
            Content = content;
        }        
	}
}