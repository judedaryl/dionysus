using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Discovery.WebApi
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;

        public VideoController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpGet]
        public FileStreamResult GetStreamAsync(string path)
        {
            var fileStream = _fileProvider.GetFileStream(path);
            return File(fileStream, $"video/{Path.GetExtension(path)}", true);
        }
    }
}