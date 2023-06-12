using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Configuration;
using System.Data.Entity;

namespace Phoneshop.Business;

public class BrandService : IBrandservice
{
   // private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
    private readonly IRepository<Brand> repository;
    private readonly ICaching<Brand> caching;
    public BrandService(IRepository<Brand> repository, ICaching<Brand> caching)
    {
        this.repository = repository;
        this.caching = caching;
    }

    public async Task InsertBrand(Brand input)
    {
        repository.Create(input);
    }

    public async Task<bool> DoesBrandExist(string Name)
    {
        bool brandExists = false;

        var result = (from t in repository.GetAll()
                      where t.Name == Name
                      select t).Any();

        return result;

        return brandExists;
    }

    public  Task<Brand?> FindBrandByName(string Name)
    {
        var brandList = repository.GetAll();

        var brand = from b in brandList
                    where b.Name == Name
                    select b;
        return  brand.SingleOrDefaultAsync();
    }

    public async Task<Brand?> GetBrandById(int id)
    {
        var _avatarCache = new SimpleMemoryCache<Brand>();
        
        var myAvatar = await _avatarCache.GetOrCreate(id, () => repository.GetById(id));
        return myAvatar;
    }

    public async Task<bool> RemoveBrand(int input)
    {
        bool isRemoved = repository.Delete(input);
        repository.SaveChanges();

        return isRemoved;
    }
}