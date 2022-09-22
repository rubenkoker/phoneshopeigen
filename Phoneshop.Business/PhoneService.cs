using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                _result = (new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
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
        string queryString = "SELECT Phones.Description,Phones.Id,Phones.Stock,Phones.Price, Brands.Name, Phones.Type FROM Phones INNER JOIN Brands ON Phones.Brands = Brands.ID; ";

        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                _result.Add(new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Brand = reader.GetString(reader.GetOrdinal("Name")),
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
        string queryString = @$"SELECT Brands.name ,Phones.type,Phones.Description,Phones.Price,Phones.Stock,Phones.Id
FROM Phones
INNER JOIN Brands ON Phones.Brands=Brands.ID
WHERE Brands.name LIKE '%{input}%' OR Type LIKE '%{input}%' OR Description LIKE '%{input}%';";
        Debug.WriteLine(queryString);
        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                _result.Add(new Phone()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Brand = reader.GetString(reader.GetOrdinal("Name")),
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

        Phone _phone = new();
        // string queryString = @$"INSERT INTO phones (Brand, Type, Description, Price,Stock)
        ///                        VALUES ('{input.Brand}', {input.Type}, '{input.Description}',{input.Price},{input.Stock});";
        string queryString = @"INSERT INTO phones (Price,Brands, Type, Description) 
  VALUES('40.00',7,'playmobiel','Hello world!');
INSERT INTO Brands ( Name)
  VALUES('test');";
        using (SqlConnection connection = new SqlConnection(
                   _connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            int _commandresult = command.ExecuteNonQuery();

            // Call Read before accessing data.

            // Call Close when done reading.

            if (_commandresult > 0)
            {
                return true;
            }
            return false;

        }

    }
    // public List<Phone> XMLRead(string path)
    //{
    ///   XDocument xml = XDocument.Load(path);

    //  foreach (var node in xml.Nodes)
    //  {
    //   if (node is XText)
    //   {

    //           MessageBox.Show(((XText) node).Value);
    //        some code...
    //    }
    //  if (node is XElement)
    ///   {
    //       some code for XElement...
    //   }
    //     }
    //   }

}
