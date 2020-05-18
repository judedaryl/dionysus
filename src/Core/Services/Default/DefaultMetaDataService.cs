namespace Discovery {
    public class DefaultMetaDataService {


        public object GetMetaData(string path) {
            var file = TagLib.File.Create(path);
            return file.Tag.Pictures;
        }
    }
}