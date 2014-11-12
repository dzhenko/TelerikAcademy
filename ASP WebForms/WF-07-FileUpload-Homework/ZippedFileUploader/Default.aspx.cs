using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ZippedFileUploader.Data.Models;

using Ionic.Zip;
using System.IO;
using ZippedFileUploader.Data;

namespace ZippedFileUploader
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var db = new FilesDbContext();

            foreach (UploadedFile file in this.RadAsyncUpload.UploadedFiles)
            {
                if (!file.FileName.EndsWith(".zip"))
                {
                    continue;
                }

                using (var zipFile = ZipFile.Read(file.InputStream))
                {
                    foreach (var zipContent in zipFile)
                    {
                        if (!zipContent.FileName.EndsWith(".txt"))
                        {
                            continue;
                        }

                        using (var stream = new MemoryStream())
                        {
                            zipContent.Extract(stream);

                            stream.Position=0;

                            var reader = new StreamReader(stream);

                            var txt = reader.ReadToEnd();

                            db.TextFiles.Add(new TextFile()
                            {
                                Name = zipContent.FileName,
                                Content = txt
                            });

                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}