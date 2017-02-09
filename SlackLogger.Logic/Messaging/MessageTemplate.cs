using System.Collections.Concurrent;

namespace SlackLogger.Logic {
	public class MessageTemplate {
        public string Content { get; set; }

        public MessageTemplate(string content) {
            Content = content;
        }        
	}
}