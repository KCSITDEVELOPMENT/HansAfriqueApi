using HansAfriqueApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Data
{
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }

        public DbSet<User> Users { get; set; }
    


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Part> Parts { get; set; }

    }
    
}
