using System.IO;

namespace Discovery
{
    public class LocalFileProvider : IFileProvider
    {
        public FileStream GetFileStream(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }
    }
}