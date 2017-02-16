using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace SlackLogger.Core {
    public static class MessageConfig {
        private static readonly string _configName = "Messages.config";
        private static readonly List<MessageInclude> _includes = new List<MessageInclude>();
        private static readonly object _syncObject = new object();
        private static SlackConfig _slackConfig;

        public static void Init(SlackConfig config) {
            _slackConfig = config;
            ParseConfig();
        }

        private static void ParseConfig() {
            lock (_syncObject) {
                _includes.Clear();
                XDocument doc = XDocument.Parse(File.ReadAllText(ConfigFilepath));
                XElement messages = doc.Element("messages");
                IEnumerable<XElement> includes = messages.Elements("include");
                foreach (XElement include in includes) {
                    _includes.Add(new MessageInclude(include));
                }
            }
        }

        public static IEnumerable<MessageInclude> Includes {
            get {
                IEnumerable<MessageInclude> result;
                lock (_syncObject) {
                    result = _includes.ToList();
                }
                return result;
            }
        }

        private static string ConfigFilepath {
            get {
                return Path.Combine(_slackConfig.TemplateRootFolder, _configName);
            }
        }
    }
}