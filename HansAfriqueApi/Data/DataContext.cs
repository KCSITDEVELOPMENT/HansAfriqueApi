using HansAfriqueApi.Entities;
using HansAfriqueApi.Entities.OrderAggregate;
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

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<PartCategory> PartCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PartNumber> PartNumbers { get; set; }
        public DbSet<FileData> Photos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    }
    
}
