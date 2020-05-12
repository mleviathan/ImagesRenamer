using System;
using System.IO;

namespace ImagesRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This little program will rename every png present in all sub-folders, removing everything from char '_'");
            Console.WriteLine("Paste the absolute path of the folder OR leave empty to rename images in current folder");
            string path = Console.ReadLine();

            path = string.IsNullOrEmpty(path) ? AppContext.BaseDirectory : path;

            RenameImagesInPath(path);

            Console.WriteLine("Done!");
        }

        private static void RenameImagesInPath(string path)
        {
            foreach (var filePath in Directory.GetFiles(path, "*.png", SearchOption.AllDirectories))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);

                if (fileName.Split('_').Length == 2)
                {
                    string currPath = Path.GetDirectoryName(filePath);
                    string newPath = Path.Combine(currPath, fileName.Split('_')[0] + fileExtension);
                    File.Move(filePath, newPath, true);
                }
            }
        }
    }
}
