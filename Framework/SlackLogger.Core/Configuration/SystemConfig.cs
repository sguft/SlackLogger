using System.IO;
using System.Reflection;

namespace SlackLogger.Core {
    internal static class SystemConfig {

        public static string AssemblyDirectory {
            get {
                string dllLocation = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(dllLocation);
                return fileInfo.DirectoryName;
            }
        }
    }
}