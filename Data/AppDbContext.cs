using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Data.configuration;
using MyStore.Models;

namespace MyStore.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        //public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().Property(pr => pr.StockQuantity).HasDefaultValue(10);
            //modelBuilder.Entity<Product>().Property(pr => pr.Updated).HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<AppUser>().HasData(new List<AppUser>() {
            // new AppUser{ UserName="Moayadmadhoun" , Email="moayad@gmail.com", PasswordHash="123456789", Address="Gaza", IsActive=true}
           
            
            //});

            //modelBuilder.Entity<AppUser>().ToTable("tblUsers");

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
           


        }
    }
}
