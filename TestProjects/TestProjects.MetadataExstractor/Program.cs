using MetadataExtractor;

namespace TestProjects.MetadataExstractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo("D:\\Videos\\Test1");

            var files = directory.GetFiles();

            foreach (var file in files)
            {
                var dirs = ImageMetadataReader.ReadMetadata(file.FullName);
                foreach (var dir in dirs)
                {
                    Console.WriteLine(dir.Name);
                }
            }
        }
    }
}
