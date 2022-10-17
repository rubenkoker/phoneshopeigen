using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    BrandService _brandService;
    public PhoneService()
    {
        _brandService = new BrandService();
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
        List<Phone> _result = new();
        string queryString = "SELECT Phones.Description,Phones.Id,Phones.Stock,Phones.Price,Brands.Name,Phones.Type FROM Phones INNER JOIN Brands ON Phones.BrandID = Brands.ID; ";

        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            Debug.WriteLine(queryString);
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Brand brand = new();
                brand.Name = reader.GetString(reader.GetOrdinal("Name"));
                _result.Add(new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Brand = brand,
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = (decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                });
            }

            // Call Close when done reading.
            reader.Close();
        }

        return _result;
    }

    public List<Phone>? Search(string input)
    {
        if (input == "")
        {
            return null;
        }
        List<Phone> _result = new();
        // string queryString = @$"SELECT * FROM Phones
        //  WHERE Brand LIKE '%{input}%' OR Type LIKE '%{input}%' OR Description LIKE '%{input}%' ; ";
        string queryString = @$"SELECT Brands.Name ,Phones.type,Phones.Description,Phones.Price,Phones.Stock,Phones.Id
FROM Phones
INNER JOIN Brands ON Phones.BrandID=Brands.ID
WHERE Brands.Name LIKE '%{input}%' OR Type LIKE '%{input}%' OR Description LIKE '%{input}%';";
        Debug.WriteLine(queryString);
        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Brand brand = new Brand();
                brand.Name = reader.GetString(reader.GetOrdinal("Name"));
                _result.Add(new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Brand = brand,
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = (decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                });
            }

            // Call Close when done reading.
            reader.Close();
        }

        return _result;
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
        int brandID;

        using (SqlConnection connection = new SqlConnection(
              _connectionString))
        {
            string GetBrandIDQueryString = @$"SELECT ID FROM Brands Where Name ='{input.Brand}'";
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
  VALUES({input.Price},7,'{input.Type}','{input.Description}','{input.Stock}');
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