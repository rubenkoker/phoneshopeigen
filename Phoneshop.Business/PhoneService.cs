using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.Entity;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    private BrandService _brandService;
    private readonly IRepository<Phone> repository;

    public PhoneService(IRepository<Phone> repository)
    {
        _brandService = new BrandService();
        this.repository = repository;
    }

    public Phone? GetPhoneById(int id)
    {
        if (id <= 0)
        {
            return repository.GetById(id);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// public getter for the phone list
    /// </summary>
    /// <returns></returns>
    public List<Phone> GetAllPhones()
    {
        List<Phone> _result = repository.GetAll().Include(Phone => Phone.Brand).ToList();

        return _result;
    }

    public List<Phone>? Search(string input)
    {
        if (input == "")
        {
            return null;
        }
        List<Phone> _result = new();
        // var context = new DataContext();
        var phonelist = repository.GetAll();
        // Query for all blogs with names starting with B
        var phones = from b in phonelist
                     where b.Description.Contains(input) || b.Type.Contains(input) || b.Brand.Name.Contains(input)
                     select b;

        return phones.ToList();
    }

    public bool AddPhone(Phone input)
    {
        repository.Create(input);
        return true;

    }

    public bool RemovePhone(int input)
    {
        bool IsRemoved = false;
        repository.Delete(input);

        return IsRemoved;
    }

    public List<Phone>? GetPhonesByBrand(Brand brand)
    {
        List<Phone> _result = new();
        //var context = new DataContext();
        var phonelist = repository.GetAll();
        // Query for all blogs with names starting with B
        var phones = from b in phonelist
                     where b.BrandID == brand.Id
                     select b;

        return phones.ToList();
    }
}