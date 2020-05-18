using System.Collections.Generic;

namespace Discovery
{
    public interface IFileDiscovery
    {
        IEnumerable<DiscoveryResult> DiscoverPath(string path, bool includeFiles);
    }
}