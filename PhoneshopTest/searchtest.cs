using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace PhoneshopTest
{
    public class searchtest
    {
        [Fact]
        public async void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var phoneservice = serviceProvider.GetRequiredService<IPhoneService>();
            //act
            List<Phone> phone = await phoneservice.GetAllPhones();

            //asses
            Assert.Equal(1, phone.Count());
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services
                .AddLogging(configure => configure.AddDebug()).Configure<LoggerFilterOptions>(options => { options.MinLevel = LogLevel.Debug; });
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<DataContext>();
                static void ConfigureServices(ServiceCollection services)
                {
                    services.AddScoped<IPhoneService, PhoneService>();
                    services.AddScoped<IBrandservice, BrandService>();
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                    services.AddDbContext<DataContext>();
                }
            }
        }

        [Fact]
        public async void GetByIDTest_ShouldReturHuaweiPhones()
        {
            //arrange
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            var phoneservice = serviceProvider.GetRequiredService<IPhoneService>();

            //act
            List<Phone> phone = await phoneservice.Search("Huawei");
            //asses
            Assert.Equal(2, phone.Count());
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services
      .AddLogging(configure => configure.AddDebug()).Configure<LoggerFilterOptions>(options => { options.MinLevel = LogLevel.Debug; });
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<DataContext>();
            }
        }
    }
}