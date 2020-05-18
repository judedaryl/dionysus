using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Discovery.WebApi
{
    [ApiController]
    [Route("[controller]")]
    public class DiscoverController : ControllerBase
    {
        private readonly IFileDiscovery _fileDiscovery;

        public DiscoverController(IFileDiscovery fileDiscovery)
        {
            _fileDiscovery = fileDiscovery;
        }

        [HttpGet]
        public IEnumerable<DiscoveryResult> DiscoverPath(string path, bool includeFiles = false) {
            return _fileDiscovery.DiscoverPath(path, includeFiles);
        }
    }
}
