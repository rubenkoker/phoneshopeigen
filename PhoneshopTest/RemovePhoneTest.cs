using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Configuration;

namespace Phoneshop.Business.Test
{
    public class should__Return_4phones_withcam
    {
        [Fact]
        public async Task GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            var services = new ServiceCollection();
            TestServices.ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = await phoneservices.GetAllPhones();
            //act
            var answer = await phoneservices.Search("cam");
            //asses

            Assert.True(answer != null);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped(typeof(ICaching<>), typeof(SimpleMemoryCache<>));
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<DataContext>();
            }
        }
    }
}