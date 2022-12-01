using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private IBrandservice _brandservice;
    private readonly IRepository<Phone> _repository;
    public readonly ILogger<PhoneService> _logger;

    public PhoneService(IRepository<Phone> repository, ILogger<PhoneService> logger, IBrandservice brandservice)
    {
        _logger = logger;
        _brandservice = brandservice;
        _repository = repository;
    }

    public async Task<Phone?> GetPhoneById(int id)
    {
        _logger.LogInformation("get phone by ID{id}",
            id);

        return _repository.GetById(id);
    }

    public async Task<List<Phone>> GetAllPhones()
    {
        List<Phone> _result = await _repository.GetAll().Include(s => s.Brand).ToListAsync();
        _logger.LogInformation("get phones: {phones}",
           _result.Count());
        return _result;
    }

    public async Task<List<Phone>> Search(string input)
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

        return await phones.ToListAsync();
    }

    public async Task<bool> AddPhone(Phone input)
    {
        _logger.LogInformation("" +
            "Added phone   ");
        if (await _brandservice.DoesBrandExist(input.Brand.Name))
        {
            input.Brand = await _brandservice.FindBrandByName(input.Brand.Name);
        }
        _repository.Create(input);
        _repository.SaveChanges();
        return true;
    }

    public async Task<bool> RemovePhone(int input)
    {
        _logger.LogInformation("phone removed visited at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        bool isRemoved = _repository.Delete(input);
        _repository.SaveChanges();

        return isRemoved;
    }

    public async Task<List<Phone>?> GetPhonesByBrand(Brand brand)
    {
        _logger.LogInformation("got phones  at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        List<Phone> _result = new();

        var phonelist = _repository.GetAll();
        // Query for all blogs with names starting with B
        var phones = from b in phonelist
                     where b.BrandID == brand.Id
                     select b;

        return await phones.ToListAsync();
    }
}