using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Xml;

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
        var context = new DataContext();

        // Query for all blogs with names starting with B
        var phones = from b in context.Phones.Include(phone => phone.Brand)
                     where b.Description.Contains(input) || b.Type.Contains(input) || b.Brand.Name.Contains(input)
                     select b;

        return phones.ToList();
    }

    public bool AddPhone(Phone input)
    {
        repository.Create(input);
        return true;

    }

    private List<Phone> XMLRead(string path)
    {
        //https://www.youtube.com/watch?v=4dPWkEARptI
        XmlDocument xml = new();
        xml.Load(path);
        XmlNodeList cList = xml.GetElementsByTagName("Phone");
        foreach (XmlNode c in cList)
        {
            Phone phone = new Phone();
            phone.Brand.Name = c["Brand"].Value;
            phone.Description = c["Description"].Value;
            phone.Stock = Int32.Parse(c["Stock"].Value);
            phone.Price = Int32.Parse(c["Price"].Value);
            phone.Type = c["Type"].Value;
        }
        return null;
    }

    public bool RemovePhone(int input)
    {
        bool IsRemoved = false;
        string queryString = @$"DELETE FROM Phones
                                WHERE Id = {input} ; ";

        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();

            int number = command.ExecuteNonQuery();
            if (number > 0)
            {
                IsRemoved = true;
            }
            // Call Read before accessing data.
        }
        return IsRemoved;
    }

    public List<Phone>? GetPhonesByBrand(Brand brand)
    {
        List<Phone> _result = new();
        var context = new DataContext();

        // Query for all blogs with names starting with B
        var phones = from b in context.Phones
                     where b.BrandID == brand.Id
                     select b;

        return phones.ToList();
    }
}