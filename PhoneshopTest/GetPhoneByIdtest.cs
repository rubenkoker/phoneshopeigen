namespace PhoneshopTest
{
    using Microsoft.Extensions.DependencyInjection;
    using Phoneshop.Business;
    using Phoneshop.Data;
    using Phoneshop.Domain.Interfaces;
    using Phoneshop.Domain.Models;
    using System.Configuration;
    using System.Diagnostics;

    public class GetPhoneByIdtest
    {
        [Fact]
        public async Task GetByIDTest_ShouldReturnIphone()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var services = serviceProvider.GetRequiredService<IPhoneService>();
            //act
            Phone phone = await services.GetPhoneById(1042);
            //asses
            Debug.WriteLine(phone.Type);
            Assert.Equal("IPhone43", phone.Type);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<DataContext>();
            }
        }

        [Fact]
        public async Task GetAllPhonesTest_shouldReturn5phones()
        {
            //arrange
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = await phoneservices.GetAllPhones();
            //act
            bool answer = await phoneservices.RemovePhone(15);

            //act
            List<Phone> phone = await phoneservices.GetAllPhones();
            //asses
            // Assert.Equal(15, phone.Count());
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
                services.AddDbContext<DataContext>();
            }
        }

        [Fact]
        public async Task GetByIDZeroTest_SHouldReturnNull()
        {
            //arrange
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = await phoneservices.GetAllPhones();
            //act
            bool answer = await phoneservices.RemovePhone(15);

            //act
            Phone phone = await phoneservices.GetPhoneById(0);
            //asses
            Assert.Null(phone);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
                services.AddDbContext<DataContext>();
            }
        }
    }
}