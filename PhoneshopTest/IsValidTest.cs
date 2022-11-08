using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business.Extensions;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Diagnostics;
namespace Phoneshop.Business.Test
{
    public class IsValidTest
    {
        [Fact]
        public void IsValidTestPositive()
        {
            var phone = new Phone();
            phone.Brand.Name = "redphone";
            phone.Price = 121;
            phone.Stock = 42;
            phone.Type = "3s";
            phone.Brand.Id = 43;
            phone.BrandID = phone.Brand.Id;
            phone.Description = "deze vietnamese telefoon is perfect voor lange afstands bellen";
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();

            string message;
            bool result = phone.IsValid(out message);
            Debug.WriteLine(message);
            Assert.True(result);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneshopEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                services.AddDbContext<DataContext>();

            }
        }

        [Fact]
        public void IsValidTestNegative()
        {
            var phone = new Phone();
            phone.Brand.Name = "redphone";
            phone.Price = 121;
            phone.Stock = 42;

            phone.BrandID = phone.Brand.Id;
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();

            string message;
            Assert.False(phone.IsValid(out message));
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneshopEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                services.AddDbContext<DataContext>();

            }
        }

    }
}