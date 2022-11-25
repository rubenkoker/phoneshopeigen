using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Configuration;

namespace Phoneshop.Business;

public class BrandService : IBrandservice
{
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
    private readonly IRepository<Brand> repository;

    public BrandService(IRepository<Brand> repository)
    {
        this.repository = repository;
    }

    public void InsertBrand(Brand input)
    {
        repository.Create(input);
    }

    public bool DoesBrandExist(string Name)
    {
        bool brandExists = false;

        var result = (from t in repository.GetAll()
                      where t.Name == Name
                      select t).Any();

        return result;

        return brandExists;
    }

    public Brand? FindBrandByName(string Name)
    {
        var brandList = repository.GetAll();

        var brand = from b in brandList
                    where b.Name == Name
                    select b;
        return brand.SingleOrDefault();
    }
}