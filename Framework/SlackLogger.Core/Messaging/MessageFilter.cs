using System.Linq;

namespace SlackLogger.Core {
    internal static class MessageFilter {
        public static bool ShouldProcess(MessageInclude include, object datasource) {
            return include.Patterns.All(p => {
                string value = ReflectionHelper.GetPropertyValue(p.PropertyName, datasource)?.ToString() ?? string.Empty;
                return p.Expression.IsMatch(value);
            });
        }
    }
}