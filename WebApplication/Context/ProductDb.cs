using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Context
{
    public class ProductDb : DbContext
    {
        public ProductDb() : base("name=CatalogConnectionString")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}