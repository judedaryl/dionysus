using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Linq;

namespace Discovery
{
    public class DefaultDiscoveryScanner
    {


        public DiscoveryResult ScanFolder(string path)
        {
            var root = new DiscoveryResult(path);
            RecursiveScan(root);
            return root;
        }

        private DiscoveryResult RecursiveScan(DiscoveryResult parent)
        {
            var path = parent.Path;
            var directories = Directory.GetDirectories(path)
            .Where(filePath => AccessUtility.HasAccess(filePath))
            .ToList().Select(filePath => new DiscoveryResult(filePath));

            foreach (var directory in directories)
            {
                RecursiveScan(directory);
                parent.AddChild(directory);
            }
            var files = Directory.GetFiles(path).ToList()
                        .Where(filePath => AccessUtility.HasAccess(filePath))
            .Where(file =>
                VideoFile.Extensions.Contains(Path.GetExtension(file), new ExtensionComparer())
            )

            .Select(filePath => new DiscoveryResult(filePath));
            foreach (var file in files)
            {
                parent.AddChild(file);
            }

            return parent;
        }
    }

    class ExtensionComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower() == y.ToLower();
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}