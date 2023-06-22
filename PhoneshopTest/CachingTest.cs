using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Test
{
    public class CachingTest
    {
        [Fact]
        public async void CacheBransTest()
        {
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);

            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();

            var repository = serviceProvider.GetRequiredService<IRepository<Brand>>();
            //act
            var _avatarCache = new SimpleMemoryCache<Brand>();
            // ...
            var expected = repository.GetById(2);
            var myAvatar = await _avatarCache.GetOrCreate(2, () => repository.GetById(2));

            //asses
            while (true)
            {
                if (myAvatar != null)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
            Assert.Equal(expected, myAvatar);
            static void ConfigureServices(ServiceCollection services)
            {
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandservice, BrandService>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<DataContext>();
                static void ConfigureServices(ServiceCollection services)
                {
                    services.AddScoped<IPhoneService, PhoneService>();
                    services.AddScoped<IBrandservice, BrandService>();
                    services.AddScoped(typeof(ICaching<>), typeof(SimpleMemoryCache<>));

                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                    services.AddDbContext<DataContext>();
                }
            }
        }
    }
}