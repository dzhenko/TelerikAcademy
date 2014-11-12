using System;
using System.Data.Entity;
using System.Linq;
using ZippedFileUploader.Data.Migrations;
using ZippedFileUploader.Data.Models;

namespace ZippedFileUploader.Data
{
    public class FilesDbContext : DbContext
    {
        public FilesDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilesDbContext, Configuration>());
        }

        public IDbSet<TextFile> TextFiles { get; set; }
    }
}