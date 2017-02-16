using System.Collections.Concurrent;
using System.Configuration;
using System.IO;

namespace SlackLogger.Core {
    public class SlackConfig {
        private string _templateRootFolder;
        public string WebhookUrl { get; set; }

        public string TemplateRootFolder {
            get {
                return _templateRootFolder;
            }
            set {
                if (value.StartsWith(".") || value.StartsWith("/") || value.StartsWith("\\")) {
                    string relativePath = GetRelativePath(value);
                    if (!string.IsNullOrWhiteSpace(relativePath)) {
                        _templateRootFolder = Path.Combine(SystemConfig.AssemblyDirectory, relativePath);
                    }
                    else {
                        _templateRootFolder = SystemConfig.AssemblyDirectory;
                    }
                    return;
                }
                _templateRootFolder = value;
            }
        }

        private string GetRelativePath(string value) {
            string result = value.Remove(0, 1);
            result = result.Replace("/", "\\");
            if (result.StartsWith("\\")) {
                result = result.Remove(0, 1);
            }
            return result;
        }
    }
}