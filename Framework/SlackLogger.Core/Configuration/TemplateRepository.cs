using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SlackLogger.Core {
    internal static class TemplateRepository {
        private static readonly string _searchPattern = "*.template.json";
        private static readonly Dictionary<string, MessageTemplate> _templates = new Dictionary<string, MessageTemplate>();
        private static SlackConfig _slackConfig;

        public static void Init(SlackConfig config) {
            _slackConfig = config;
            LoadTemplates();
        }

        public static MessageTemplate GetTemplate(string relativeFilePath) {
            return _templates[CleanupFilepath(relativeFilePath)];
        }

        private static void LoadTemplates() {
            IEnumerable<string> files = Directory.EnumerateFiles(_slackConfig.TemplateRootFolder, _searchPattern, SearchOption.AllDirectories);
            foreach (string filepath in files) {
                LoadTemplate(filepath);
            }            
        }

        private static void LoadTemplate(string filepath) {            
            string templateContent = File.ReadAllText(filepath);
            string relativeFilePath = GetRelativePath(filepath);
            MessageTemplate template = new MessageTemplate(templateContent);
            _templates.Add(relativeFilePath, template);
        }

        private static string GetRelativePath(string filepath) {
            string result = filepath.Replace(_slackConfig.TemplateRootFolder, string.Empty);
            return CleanupFilepath(result);
        }

        private static string CleanupFilepath(string filepath) {            
            if (filepath.StartsWith("\\")) {
                filepath = filepath.Remove(0, 1);
            }
            filepath = filepath.Replace("\\", "/");
            return filepath.ToLower();
        }
    }
}