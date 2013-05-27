using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
namespace jnu_actroom.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }
        public int CollegeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class CatalogDBContext : DbContext
    {
        public DbSet<CatalogModel> Catalogs { get; set; }
    }
}