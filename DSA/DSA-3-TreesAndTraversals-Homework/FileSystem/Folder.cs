namespace FileSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class JFolder
    {
        private ICollection<JFile> files;
        private ICollection<JFolder> subFolders;

        public JFolder(string name)
        {
            this.Name = name;
            this.files = new List<JFile>();
            this.subFolders = new List<JFolder>();
        }

        public string Name { get; set; }

        public ICollection<JFile> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }

        public ICollection<JFolder> SubFolders
        {
            get
            {
                return this.subFolders;
            }
            set
            {
                this.subFolders = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public long GetSizeFromHere()
        {
            return this.Files.Sum(f => f.Size) + this.SubFolders.Sum(f => f.GetSizeFromHere());
        }
    }
}
