using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Test.PhoneServiceTests
{
    public class AddPhoneTest
    {
        [Fact]
        public async Task GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var phoneservices = serviceProvider.GetRequiredService<IPhoneService>();

            Phone phone = new();
            phone.Brand.Name = "fairphone";
            phone.Stock = 8;
            phone.Price = 500m;
            phone.Description = "deze nederlandse telefoon is fairtrade en heef 5g";
            phone.Type = "4";

            bool Result = await phoneservices.AddPhone(phone);
            //act

            //asses
            Assert.True(Result);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped<ICaching<Brand>, SimpleMemoryCache<Brand>>();
                services
            .AddLogging(configure => configure.AddDebug()).Configure<LoggerFilterOptions>(options => { options.MinLevel = LogLevel.Debug; });
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneshopEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                services.AddDbContext<DataContext>();
            }
        }
    }
}