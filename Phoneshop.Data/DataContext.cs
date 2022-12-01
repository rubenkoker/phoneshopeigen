using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Models;
using PhoneShop.Domain;

namespace Phoneshop.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}