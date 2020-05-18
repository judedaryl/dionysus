using System.IO;

namespace Discovery
{
    public interface IFileProvider
    {
        FileStream GetFileStream(string path);
    }
}