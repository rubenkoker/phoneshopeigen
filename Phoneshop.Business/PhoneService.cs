using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Configuration;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{

    private IBrandservice brandservice;
    private readonly IRepository<Phone> _repository;
    public PhoneService(IRepository<Phone> repository)
    {
        ServiceCollection phoneservices = new();
        ConfigureServices(phoneservices);
        ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
        brandservice = serviceProvider.GetRequiredService<IBrandservice>();

        void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IBrandservice, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            string connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connectionString));

        }

        this._repository = repository;
    }

    public Phone? GetPhoneById(int id)
    {

        return _repository.GetById(id);

    }

    /// <summary>
    /// public getter for the phone list
    /// </summary>
    /// <returns></returns>
    public List<Phone> GetAllPhones()
    {
        List<Phone> _result = _repository.GetAll().Include(s => s.Brand).ToList();

        return _result;
    }

    public List<Phone>? Search(string input)
    {
        if (input == "")
        {
            return null;
        }
        List<Phone> _result = new();

        var phonelist = _repository.GetAll();

        var phones = from b in phonelist
                     where b.Description.Contains(input) || b.Type.Contains(input) || b.Brand.Name.Contains(input)
                     select b;

        return phones.ToList();
    }

    public bool AddPhone(Phone input)
    {
        if (brandservice.DoesBrandExist(input.Brand.Name))
        {
            input.Brand = brandservice.FindBrandByName(input.Brand.Name);
        }
        _repository.Create(input);
        _repository.SaveChanges();
        return true;

    }

    public bool RemovePhone(int input)
    {
        bool IsRemoved = false;
        _repository.Delete(input);
        _repository.SaveChanges();
        return IsRemoved;
    }

    public List<Phone>? GetPhonesByBrand(Brand brand)
    {
        List<Phone> _result = new();
        //var context = new DataContext();
        var phonelist = _repository.GetAll();
        // Query for all blogs with names starting with B
        var phones = from b in phonelist
                     where b.BrandID == brand.Id
                     select b;

        return phones.ToList();
    }
}
