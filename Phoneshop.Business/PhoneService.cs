using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    BrandService _brandService;
    private readonly IRepository<Phone> repository;

    public PhoneService(IRepository<Phone> repository)
    {
        _brandService = new BrandService();
        this.repository = repository;
    }

    public Phone? GetPhoneById(int input)
    {
        Phone? _result = new();
        string queryString = @$"SELECT * FROM Phones
                                WHERE Id = {input} ; ";

        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            if (reader.Read())
            {
                Brand brand = new Brand();
                brand.Name = reader.GetString(reader.GetOrdinal("Brand"));
                _result = (new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                    Brand = brand,
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = (decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                });
            }
            else
            {
                _result = null;
            }
            // Call Close when done reading.
            reader.Close();
        }

        return _result;
    }

    /// <summary>
    /// public getter for the phone list
    /// </summary>
    /// <returns></returns>
    public List<Phone> GetAllPhones()
    {

        List<Phone> _result = repository.GetAll().ToList();


        return _result;
    }

    public List<Phone>? Search(string input)
    {

        if (input == "")
        {
            return null;
        }
        List<Phone> _result = new();
        var context = new PhoneshopContext();

        // Query for all blogs with names starting with B
        var phones = from b in context.Phones
                     where b.Description.Contains(input) || b.Type.Contains(input) || b.Brand.Name.Contains(input)
                     select b;

        return phones.ToList();
    }

    public bool AddPhone(Phone input)
    {

        string CheckQuery = @$"SELECT ID
FROM Brands
WHERE Name = '{input.Brand}'; ";
        Debug.WriteLine(CheckQuery);
        bool BrandExists = false;
        Debug.WriteLine(CheckQuery);
        BrandExists = _brandService.DoesBrandExist(CheckQuery, BrandExists);
        if (!BrandExists)
        {
            _brandService.InsertBrand(input);
        }
        int brandID = 0;

        using (SqlConnection connection = new SqlConnection(
              _connectionString))
        {
            string GetBrandIDQueryString = @$"SELECT ID FROM Brands Where Name ='{input.Brand.Name}'";
            Debug.WriteLine("nee" + GetBrandIDQueryString);
            SqlCommand command = new SqlCommand(GetBrandIDQueryString, connection);

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            if (reader.Read())
            {
                brandID = reader.GetInt32(reader.GetOrdinal("Id"));
            }

            string queryString = @$"INSERT INTO phones (Price,BrandID, Type, Description,stock)
  VALUES({input.Price},{brandID},'{input.Type}','{input.Description}','{input.Stock}');
";
            Debug.WriteLine(queryString);
            using (SqlConnection insertconnection = new SqlConnection(
                       _connectionString))
            {
                SqlCommand getcommand = new SqlCommand(queryString, insertconnection);
                getcommand.Connection.Open();
                int _commandresult = getcommand.ExecuteNonQuery();
                Debug.WriteLine(queryString);
                // Call Read before accessing data.

                // Call Close when done reading.

                if (_commandresult > 0)
                {
                    return true;
                }
                return false;
            }
        }

    }
    List<Phone> XMLRead(string path)
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

}