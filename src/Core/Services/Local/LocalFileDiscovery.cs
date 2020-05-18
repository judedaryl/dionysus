using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using Microsoft.Extensions.Logging;

namespace Discovery
{
    public class LocalFileDiscovery : IFileDiscovery
    {

        private readonly ILogger<LocalFileDiscovery> _logger;

        public LocalFileDiscovery(ILogger<LocalFileDiscovery> logger)
        {
            _logger = logger;
        }

        public IEnumerable<DiscoveryResult> DiscoverPath(string path, bool includeFiles)
        {
            IEnumerable<DiscoveryResult> result = Enumerable.Empty<DiscoveryResult>();

            try
            {
                var directories = Directory.GetDirectories(path)
                .Where(
                    dirPath => AccessUtility.HasAccess(dirPath)
                )
                .Select(
                    dirPath => new DiscoveryResult(dirPath)
                );

                result = result.Concat(directories);

                if (includeFiles)
                {
                    var files = Directory.GetFiles(path)
                    .Where(
                        filePath => AccessUtility.HasAccess(filePath)
                    )
                    .Select(
                        filePath => new DiscoveryResult(filePath)
                    );
                    result = result.Concat(files);
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(1, exc, "Error listing directory and files");
            }

            return result;
        }
    }
}