namespace _03.FileSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        private List<File> files;
        private List<Folder> folders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>() ;
            this.folders = new List<Folder>();
        }

        public string Name { get; private set; }
        public File[] Files { get { return this.files.ToArray(); } }
        public Folder[] ChildFolders { get { return this.folders.ToArray(); } }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddSubFolder(Folder folder)
        {
            this.folders.Add(folder);
        }

        public double GetSizeFromHere()
        {
            double totalSize = 0;

            foreach (var file in this.Files)
            {
                totalSize += file.Size;
            }

            foreach (var subfolder in this.ChildFolders)
            {
                foreach (var file in subfolder.Files)
                {
                    totalSize += file.Size;
                }
            }

            return totalSize;
        }

        public override string ToString()
        {
            return this.Name + "[Subfolders Count: " + this.ChildFolders.Length + "]";
        }
    }
}
