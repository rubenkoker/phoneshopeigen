namespace PhoneshopTest
{
    using Microsoft.Extensions.DependencyInjection;
    using Phoneshop.Business;
    using Phoneshop.Data;
    using Phoneshop.Domain.Interfaces;
    using Phoneshop.Domain.Models;
    using System.Diagnostics;
    public class GetPhoneByIdtest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnIphone()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var services = serviceProvider.GetRequiredService<IPhoneService>();
            //act
            Phone phone = services.GetPhoneById(1042);
            //asses
            Debug.WriteLine(phone.Type);
            Assert.Equal("IPhone 34", phone.Type);
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
        public void GetAllPhonesTest_shouldReturn5phones()
        {
            //arrange
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = phoneservices.GetAllPhones();
            //act
            bool answer = phoneservices.RemovePhone(15);

            //act
            List<Phone> phone = phoneservices.GetAllPhones();
            //asses
            // Assert.Equal(15, phone.Count());
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
        public void GetByIDZeroTest_SHouldReturnNull()
        {
            //arrange
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = phoneservices.GetAllPhones();
            //act
            bool answer = phoneservices.RemovePhone(15);

            //act
            Phone phone = phoneservices.GetPhoneById(0);
            //asses
            Assert.Null(phone);
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