using System;
using System.IO;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Discovery.WebApi
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {

        [HttpGet]
        public object GetMetaData(string filePath)
        {
            var scanner = new DefaultDiscoveryScanner();
            BackgroundJob.Enqueue(() => Console.WriteLine("WZAUp"));
            var metadata = new DefaultMetaDataService();
            return scanner.ScanFolder(filePath);
            // return metadata.GetMetaData(filePath);
            //    var fileInfo = new FileInfo(filePath);
            //    fileInfo.
            //    return fileInfo;
        }
    }
}