using System.Text.RegularExpressions;
using System.Web;

namespace SlackLogger.Core {
    public static class TemplateCompiler {
        private static readonly Regex _statementRegex = new Regex(@"<%\s*(?<statement>.+?)(:(?<format>.+?))?\s*%>", RegexOptions.Compiled);

        public static string Compile(MessageTemplate template, object datasource) {
            return _statementRegex.Replace(template.Content, m => {
                string statement = m.Groups["statement"]?.Value;
                string format = m.Groups["format"]?.Value;
                return ReplaceStatement(statement, format, datasource);
            });
        }

        private static string ReplaceStatement(string statement, string format, object datasource) {
            object result = ReflectionHelper.GetPropertyValue(statement, datasource);
            if (result != null) {
                return JsonEscapeValue(FormatValue(result, format));
            }
            return $"{{{{ Statement '{statement}' not found }}}}";
        }

        private static string FormatValue(object value, string format) {
            if (string.IsNullOrWhiteSpace(format)) {
                return value.ToString();
            }            
            return string.Format($"{{0:{format}}}", value);
        }

        private static string JsonEscapeValue(string value) {
            return HttpUtility.JavaScriptStringEncode(value, false);
        }
    }
}