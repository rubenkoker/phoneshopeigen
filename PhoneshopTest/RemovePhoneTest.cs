using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Test
{
    public class should__Return_4phones_withcam
    {
        [Fact]
        public async Task GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();
            List<Phone> Baselist = await phoneservices.GetAllPhones();
            //act
            bool answer = await phoneservices.RemovePhone(15);
            //asses

            Assert.True(answer);
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