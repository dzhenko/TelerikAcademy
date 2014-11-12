using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysStore.Data
{
    public interface IToysStoreEntities
    {
        DbSet<AgeRanx> AgeRanges { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<Toy> Toys { get; set; }

        void SaveChanges();
    }
}
