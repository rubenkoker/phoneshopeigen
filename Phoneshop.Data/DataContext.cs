using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phoneshop.Domain.Models;
using PhoneShop.Domain;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Phoneshop.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string _connectionString = "Data Source=sqlserver,1433;User ID=sa;Password=GeitenMekker21!;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                optionsBuilder.UseSqlServer(_connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var brandPronoun = new Brand { Name = "Pronoun", Id = 1 };
            modelBuilder.Entity<Brand>().HasData(brandPronoun);
            modelBuilder.Entity<Phone>().HasData(new Phone { BrandID = brandPronoun.Id, Type = "ourphone", Description = "our newest phone comrade", Price = 5, Id = 1 });
            //modelBuilder.Entity<Phone>().HasData(new Phone { BrandID = 1, Type = "yourphone", Description = "freedom isn't free", Price = 5, Id = 2 });
        }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}