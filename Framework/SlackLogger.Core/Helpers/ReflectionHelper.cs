using System;
using System.Reflection;

namespace SlackLogger.Core {
	public static class ReflectionHelper {
        public static object GetPropertyValue(string propertyName, object datasource) {
            Type type = datasource.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            return property?.GetValue(datasource);
        }
    }
}