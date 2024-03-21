using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbContext.Models
{
    using System.Data.Entity;

    namespace DbContext.Models
    {
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }

    }
    