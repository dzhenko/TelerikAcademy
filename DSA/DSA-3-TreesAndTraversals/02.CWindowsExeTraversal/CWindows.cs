//Write a program to traverse the directory C:\WINDOWS and all its subdirectories 
//recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.

namespace _02.CWindowsExeTraversal
{
    using System;
    using System.IO;
    using System.Text;

    public class CWindows
    {
        public static StringBuilder allExeFiles = new StringBuilder();

        public static void Main()
        {
            string dirToBeguinWith = @"C:\Windows\";

            DFS(dirToBeguinWith);

            Console.Write(allExeFiles);
        }

        private static void DFS(string dirToSearch)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(dirToSearch))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        if (file.EndsWith(".exe"))
                        {
                            allExeFiles.AppendLine(file);
                        }
                    }

                    DFS(dir);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
