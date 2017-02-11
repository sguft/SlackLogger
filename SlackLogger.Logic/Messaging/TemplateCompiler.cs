using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace SlackLogger.Logic {
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
            object result = TryBindToProperty(statement, datasource);
            if (result != null) {
                return EscapeValue(FormatValue(result, format));
            }
            return $"{{{{ Statement '{statement}' not found }}}}";
        }

        private static object TryBindToProperty(string statement, object datasource) {
            Type type = datasource.GetType();
            PropertyInfo property = type.GetProperty(statement, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);            
            return property?.GetValue(datasource);
        }

        private static string FormatValue(object value, string format) {
            if (string.IsNullOrWhiteSpace(format)) {
                return value.ToString();
            }            
            return string.Format($"{{0:{format}}}", value);
        }

        private static string EscapeValue(string value) {
            return value.Replace("\"", "\\\"").Replace("\r\n", "\\n").Replace("\n", "\\n");
        }
    }
}