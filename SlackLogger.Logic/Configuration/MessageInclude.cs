using System.Collections.Generic;
using System.Xml.Linq;

namespace SlackLogger.Logic {
    public class MessageInclude {
        private readonly List<IncludePattern> _includePatterns = new List<IncludePattern>();
        public string TemplateFile { get; set; }

        public MessageInclude(XElement include) {
            TemplateFile = include.Attribute("templateFile")?.Value ?? string.Empty;
            foreach (XElement pattern in include.Elements("pattern")) {
                _includePatterns.Add(new IncludePattern(pattern));
            }            
        }

        public IEnumerable<IncludePattern> Patterns {
            get {
                return _includePatterns;
            }
        }
    }
}