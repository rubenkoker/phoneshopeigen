using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Test
{
    internal class TestServices
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped(typeof(ICaching<>), typeof(SimpleMemoryCache<>));
            services
      .AddLogging(configure => configure.AddDebug()).Configure<LoggerFilterOptions>(options => { options.MinLevel = LogLevel.Debug; });
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandservice, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            var config = new Mock<IConfiguration>();
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            config.Setup(x => x["ConnectionStrings:PhoneshopDatabase"])
                .Returns(_connectionString);
            services.AddSingleton(config.Object);
            services.AddDbContext<DataContext>();
        }
    }
}