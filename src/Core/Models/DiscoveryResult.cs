using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace Discovery
{
    public class DiscoveryResult
    {
        public string Display { get; set; }
        public string Path { get; set; }
        public DiscoveryResultType DiscoveryType { get; set; }
        public string DiscoveryTypeDisplay => DiscoveryType.ToString();
        public IList<DiscoveryResult> Children { get; set; } = new List<DiscoveryResult>();
        
        public DiscoveryResult() { }

        public DiscoveryResult(string path)
        {
            path = path.Replace('\\', '/');
            var pathArray = path.Split('/').ToList();
            Path = path;
            Display = pathArray.LastOrDefault();
            var hasExtension = System.IO.Path.GetExtension(path) != string.Empty;
            DiscoveryType = hasExtension ? DiscoveryResultType.File : DiscoveryResultType.Folder;
        }

        public void AddChild(DiscoveryResult child)
        {
            Children.Add(child);
        }
    }
}