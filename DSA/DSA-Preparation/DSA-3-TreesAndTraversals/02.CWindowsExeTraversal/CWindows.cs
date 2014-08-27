//Write a program to traverse the directory C:\WINDOWS and all its subdirectories 
//recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.

namespace _02.CWindowsExeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CWindows
    {
        public static HashSet<string> allExeFiles = new HashSet<string>();

        public static void Main()
        {
            string dirToBeguinWith = @"C:\Windows\";

            DFS(dirToBeguinWith);

            Console.Write(string.Join(Environment.NewLine,allExeFiles));
        }

        private static void DFS(string dirToSearch)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dirToSearch))
                {
                    if (file.EndsWith(".exe"))
                    {
                        allExeFiles.Add(file);
                    }
                }

                foreach (string dir in Directory.GetDirectories(dirToSearch))
                {
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
