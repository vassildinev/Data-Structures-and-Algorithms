namespace TraverseWinDir
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var rootDirectory = new DirectoryInfo(@"C:/Windows");
            TraverseDir(rootDirectory);
        }

        private static void TraverseDir(DirectoryInfo root)
        {
            IEnumerable<DirectoryInfo> childDirectories = root.EnumerateDirectories();
            IEnumerable<FileInfo> childFiles = root.EnumerateFiles();

            foreach (var item in childFiles)
            {
                if (item.Extension == ".exe")
                {
                    Console.WriteLine(item.FullName);
                }
            }

            if (!childDirectories.Any())
            {
                return;
            }

            foreach (var item in root.EnumerateDirectories())
            {
                // Easiest way to traverse all directories with access allowed
                try
                {
                    TraverseDir(item);
                }
                catch
                {
                }
            }
        }
    }
}
