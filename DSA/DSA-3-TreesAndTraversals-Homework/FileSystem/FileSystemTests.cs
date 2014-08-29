namespace FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileSystemTests
    {
        public static void Main()
        {
            // otherwise its slow
            const string StartFolder = @"C:\Windows\Help";

            var root = new JFolder(StartFolder);

            FillFolderWithFiles(new DirectoryInfo(StartFolder), root);

            PrintFromFolder(root, 0);

            Console.WriteLine("Total size is {0} bytes", root.GetSizeFromHere());
        }

        public static void FillFolderWithFiles(DirectoryInfo dir, JFolder folder)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                folder.Files.Add(new JFile(file.Name, file.Length));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                var subFolder = new JFolder(subDir.Name);
                folder.SubFolders.Add(subFolder);
                FillFolderWithFiles(subDir, subFolder);
            }
        }

        private static void PrintFromFolder(JFolder folder, int offset)
        {
            Console.Write(new string('-', offset) + folder.Name);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var subfolder in folder.SubFolders)
            {
                PrintFromFolder(subfolder, offset + 2);
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset) + file.Name);
            }
        }
    }
}
