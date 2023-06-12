using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phoneshop.Domain.Models;
using PhoneShop.Domain;

namespace Phoneshop.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        private readonly IConfiguration _config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _connectionString = _config["ConnectionStrings:PhoneshopDatabase"]!;
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}