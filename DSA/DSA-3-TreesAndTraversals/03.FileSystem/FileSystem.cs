//Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
//and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
//Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
//Use recursive DFS traversal.


namespace _03.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class FileSystem
    {
        public static Folder root = new Folder("root");

        public static void Main()
        {
            string startDir = @"C:\Windows\";

            DFS(startDir, root);

            var allSize = root.GetSizeFromHere();

            Console.WriteLine(allSize);
        }

        private static void DFS(string dirToSearchIn, Folder currentDir)
        {
            try
            {
                //adding all files to current dir
                foreach (var file in Directory.GetFiles(dirToSearchIn))
                {
                    currentDir.AddFile(new File(file,new FileInfo(file).Length));
                }

                //adding all childDirs to current dir
                foreach (var dir in Directory.GetDirectories(dirToSearchIn))
                {
                    currentDir.AddSubFolder(new Folder(dir));
                    DFS(dir, currentDir.ChildFolders[currentDir.ChildFolders.Length - 1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
