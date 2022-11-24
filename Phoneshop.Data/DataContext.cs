using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Models;

namespace Phoneshop.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Debug.WriteLine(ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //entities
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}