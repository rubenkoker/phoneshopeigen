using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace PhoneshopTest
{
    public class searchtest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var phoneservice = serviceProvider.GetRequiredService<IPhoneService>();
            //act
            List<Phone> phone = phoneservice.GetAllPhones();

            //asses
            Assert.Equal(1, phone.Count());
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneshopEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                services.AddDbContext<DataContext>();
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
        [Fact]
        public void GetByIDTest_ShouldReturHuaweiPhones()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var phoneservice = serviceProvider.GetRequiredService<IPhoneService>();

            //act
            List<Phone> phone = phoneservice.Search("Huawei");
            //asses
            Assert.Equal(2, phone.Count());
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