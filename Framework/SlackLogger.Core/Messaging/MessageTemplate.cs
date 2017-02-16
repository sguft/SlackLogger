using System.Collections.Concurrent;

namespace SlackLogger.Core {
    internal class MessageTemplate {
        public string Content { get; set; }

        public MessageTemplate(string content) {
            Content = content;
        }        
	}
}