using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Models;

namespace Phoneshop.Data
{
    public class PhoneshopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshopentities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
