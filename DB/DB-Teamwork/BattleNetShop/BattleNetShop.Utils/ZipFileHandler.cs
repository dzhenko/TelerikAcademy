namespace BattleNetShop.Utils
{
    using System.IO;

    using Ionic.Zip;

    public class ZipFileHandler
    {
        public void UnzipFolder(string sourceFolderPath, string destinationFolderPath)
        {
            using (var zippedSubjects = ZipFile.Read(sourceFolderPath))
            {
                foreach (var subject in zippedSubjects)
                {
                    subject.Extract(destinationFolderPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public void ZipFolder(string sourceFolderPath, string destinationFolderPath)
        {
            using (var zip = new ZipFile())
            {
                foreach (var dir in Directory.GetDirectories(sourceFolderPath))
                {
                    zip.AddDirectory(dir, dir.Substring(dir.IndexOf("SalesReports") + 13));
                }

                zip.Save(destinationFolderPath);
            }
        }
    }
}
