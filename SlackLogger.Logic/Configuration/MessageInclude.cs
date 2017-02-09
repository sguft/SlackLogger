using System.Collections.Concurrent;
using System.Xml.Linq;

namespace SlackLogger.Logic {
	public class MessageInclude {
        public string TemplateFile { get; set; }
        public string LogLevelPattern { get; set; }
        public string MessagePattern { get; set; }

        public MessageInclude(XElement include) {
            TemplateFile = include.Attribute("templateFile")?.Value ?? string.Empty;
            LogLevelPattern = include.Attribute("logLevel")?.Value ?? string.Empty;
            MessagePattern = include.Attribute("message")?.Value ?? string.Empty;
        }        
    }
}