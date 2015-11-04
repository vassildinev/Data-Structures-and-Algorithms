namespace FilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string rootFolderPath = @"C:/Windows";
            var rootDirectory = new DirectoryInfo(rootFolderPath);

            var rootFolder = new Folder();
            Console.Write(value: "Building folder tree");
            BuildTree(rootDirectory, rootFolder);
            Console.WriteLine();

            Console.WriteLine($"{rootFolderPath} size in GB excluding forbidden access folders:{Math.Round(CalculateSizeOfSubtreeWithRoot(rootFolder) / (decimal)Math.Pow(2, 30), 2)} GB");
        }

        private static decimal CalculateSizeOfSubtreeWithRoot(Folder root)
        {
            decimal currentSize = 0;
            File[] files = root.Files;
            Folder[] folders = root.ChildFolders;

            foreach (var item in files)
            {
                currentSize += item.Size;
            }

            if (folders.Count() == 0)
            {
                return currentSize;
            }

            foreach (var item in folders)
            {
                try
                {
                    currentSize += CalculateSizeOfSubtreeWithRoot(item);
                }
                catch
                {
                }
            }

            return currentSize;
        }

        private static void BuildTree(DirectoryInfo rootDirectory, Folder rootFolder)
        {
            rootFolder.Name = rootDirectory.Name;

            IList<DirectoryInfo> subDirectories = rootDirectory.EnumerateDirectories().ToList();
            IList<FileInfo> files = rootDirectory.EnumerateFiles().ToList();
            rootFolder.Files = new File[files.Count()];
            rootFolder.ChildFolders = new Folder[subDirectories.Count()];

            for (int i = 0; i < files.Count(); i++)
            {
                rootFolder.Files[i] = new File
                {
                    Name = files[i].Name,
                    Size = files[i].Length
                };
            }

            if (subDirectories.Count() == 0)
            {
                return;
            }

            for (int i = 0; i < subDirectories.Count(); i++)
            {
                rootFolder.ChildFolders[i] = new Folder();
                try
                {
                    BuildTree(subDirectories[i], rootFolder.ChildFolders[i]);
                }
                catch
                {
                }

                if (i != 0 && i % 100 == 0)
                {
                    Console.Write(value: ".");
                }
            }
        }
    }
}
