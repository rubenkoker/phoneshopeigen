using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private IBrandservice brandservice;
    private readonly IRepository<Phone> _repository;
    public readonly ILogger<PhoneService> _logger;

    public PhoneService(IRepository<Phone> repository, ILogger<PhoneService> logger, IBrandservice brandservice)
    {
        ServiceCollection phoneservices = new();

        ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();

        _logger = logger;
        this.brandservice = brandservice;
        this._repository = repository;
    }

    public Phone? GetPhoneById(int id)
    {
        _logger.LogInformation("get phone by ID{id}",
            id);

        return _repository.GetById(id);
    }

    /// <summary>
    /// public getter for the phone list
    /// </summary>
    /// <returns></returns>
    public List<Phone> GetAllPhones()
    {
        List<Phone> _result = _repository.GetAll().Include(s => s.Brand).ToList();
        _logger.LogInformation("get phones: {phones}",
           _result.Count());
        return _result;
    }

    public List<Phone> Search(string input)
    {
        _logger.LogInformation("searched for {query} ",
            input);

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
        _logger.LogInformation("" +
            "Added phone   ");
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
        _logger.LogInformation("phone removed visited at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        bool IsRemoved = false;
        _repository.Delete(input);
        _repository.SaveChanges();
        return IsRemoved;
    }

    public List<Phone>? GetPhonesByBrand(Brand brand)
    {
        _logger.LogInformation("got phones  at {DT}",
            DateTime.UtcNow.ToLongTimeString());
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