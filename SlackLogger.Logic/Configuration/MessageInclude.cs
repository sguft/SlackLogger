using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SlackLogger.Logic {
	public class MessageInclude {
        public string TemplateFile { get; set; }
        public Regex LogLevelPattern { get; set; }
        public Regex MessagePattern { get; set; }

        public MessageInclude(XElement include) {
            TemplateFile = include.Attribute("templateFile")?.Value ?? string.Empty;
            LogLevelPattern = GetRegex(include.Element("logLevel")?.Value ?? string.Empty);
            MessagePattern = GetRegex(include.Element("message")?.Value ?? string.Empty);
        }

        private Regex GetRegex(string pattern) {
            return new Regex(pattern, RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
    }
}