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

    public  Task<List<Phone>> Search(string searchquery)
    {
        _logger.LogInformation("searched for {query} ",
            searchquery);

        if (String.IsNullOrEmpty(searchquery))
        {
            return null;
        }

        var phonelist = _repository.GetAll();

        var phones = from b in phonelist
                     where b.Description.Contains(searchquery) || b.Type.Contains(searchquery) || b.Brand.Name.Contains(searchquery)
                     select b;

        return  phones.ToListAsync();
    }

    public async Task<bool> AddPhone(Phone input)
    {
       
        if (await _brandservice.DoesBrandExist(input.Brand.Name))
        {
            input.Brand = await _brandservice.FindBrandByName(input.Brand.Name);
        }
        _repository.Create(input);
        _repository.SaveChanges();
             _logger.LogInformation("" +
            "Added phone   ");
        return true;
    }

    public async Task<bool> RemovePhone(int input)
    {
        

        bool isRemoved = _repository.Delete(input);
        _repository.SaveChanges();
        _logger.LogInformation("phone removed visited at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        return isRemoved;
    }

    public async Task<List<Phone>?> GetPhonesByBrand(Brand brand)
    {
       
        List<Phone> _result = new();

        var phonelist = _repository.GetAll();
        
        var phones = from b in phonelist
                     where b.BrandID == brand.Id
                     select b;
        _logger.LogInformation("got phones  at {DT}",
           DateTime.UtcNow.ToLongTimeString());
        return await phones.ToListAsync();
    }
}