﻿using Microsoft.EntityFrameworkCore;
using UdemySalesWebApp.Domain.Entities;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleProducts> SaleProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SaleProducts>().HasKey(x => new { x.CodigoSale, x.CodigoProduct });

            builder.Entity<SaleProducts>()
                .HasOne(x => x.Sale)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CodigoSale);

            builder.Entity<SaleProducts>()
                .HasOne(x => x.Product)
                .WithMany(y => y.Sale)
                .HasForeignKey(x => x.CodigoProduct);

        }
    }
}
