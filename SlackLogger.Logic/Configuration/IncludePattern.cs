using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SlackLogger.Logic {
    public class IncludePattern {
        public string PropertyName { get; set; }
        public string Pattern { get; set; }
        public Regex Expression { get; set; }

        public IncludePattern(XElement include) {
            PropertyName = include.Attribute("property")?.Value ?? string.Empty;
            Pattern = include.Value ?? string.Empty;
            Expression = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
    }
}