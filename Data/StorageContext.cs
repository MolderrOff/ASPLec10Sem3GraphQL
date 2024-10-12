using ASPLec10Sem3GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASPLec10Sem3GraphQL.Data
{
    public class StorageContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups  { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        //private readonly string _dbConnectionString;
        //private readonly IConfiguration _configuration;
        //public StorageContext() { }

        //public storagecontext(iconfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public StorageContext() { }
        public StorageContext(DbContextOptions<StorageContext> dbContext) : base(dbContext) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=master1;Trusted_Connection=True;TrustServerCertificate=True")
            .LogTo(Console.WriteLine); //Было "Server=MOLDERR-PC\\SQLEXPRESS;Database=Products;Trusted_Connection=True" //_dbConnectionString
                                       //    .UseLazyLoadingProxies()
                                       //    .LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ProductGroup>(entity =>
           {
               entity.HasKey(pg => pg.Id)
                     .HasName("productgroup_pk");

               entity.ToTable("category"); //название таблицы в бд

                entity.Property(pg => pg.Name)
                     .HasColumnName("name")
                     .HasMaxLength(255);
           });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id)
                      .HasName("product_pk");

                entity.Property(p => p.Name)
                     .HasColumnName("name")
                     .HasMaxLength(255);

                entity.HasOne(p => p.ProductGroup).WithMany(p => p.Products).HasForeignKey(p => p.ProductGroupId);
               
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(s => s.Id)
                      .HasName("storage_pk");

                entity.HasOne(s => s.Product).WithMany(p => p.Storages).HasForeignKey(p => p.ProductId);

            });
        }
        // "Server=MOLDERR-PC\\SQLEXPRESS;Database=CarShop;Trusted_Connection=True"
        // "Data Source = .\\SQLEXPRESS;Initial Catalog = Store;Trusted_Connection=True;TrustedServerCertificate=True"
    }
}
