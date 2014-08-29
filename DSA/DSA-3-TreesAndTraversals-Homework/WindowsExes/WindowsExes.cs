namespace WindowsExes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WindowsExes
    {
        public static void Main()
        {
            // this is slow - many files
            var startDir = new DirectoryInfo("C:\\Windows");

            TraverseDirectory(startDir);
        }
        public static void TraverseDirectory(DirectoryInfo dir)
        {
            try
            {
                var exeFiles = dir.GetFiles().Where(x => x.Extension == ".exe");
                foreach (var file in exeFiles)
                {
                    Console.WriteLine(file.FullName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Access to folder {0} is denied", dir.FullName);
                return;
            }

            foreach (var subDir in dir.GetDirectories())
            {
                TraverseDirectory(subDir);
            }
        }
    }
}
