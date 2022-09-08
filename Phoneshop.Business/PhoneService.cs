using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{

    /// <summary>
    /// returns the phone corresponding to the ID
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Phone? GetPhoneById(int input)
    {
        Phone _result = new();
        string queryString = @$"SELECT * FROM Phones
                                WHERE Id LIKE '%{input}%' ; ";
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.

            _result = (new Phone()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Brand = reader.GetString(reader.GetOrdinal("Brand")),
                Type = reader.GetString(reader.GetOrdinal("Type")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Price = (Decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),

            });

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
        string queryString = "SELECT * FROM Phones";
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (SqlConnection connection = new SqlConnection(
                   connectionString))
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
                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = (Decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),

                });
            }

            // Call Close when done reading.
            reader.Close();
        }

        return _result;
    }

    /// <summary>
    ///search function fot hte phone list (non case sensitive)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public List<Phone>? SearchPhonesByString(string input)
    {
        List<Phone> _result = new();
        string queryString = @$"SELECT * FROM Phones
                                WHERE Brand LIKE '%{input}%' OR Type LIKE '%{input}%' OR Description LIKE '%{input}%' ; ";
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (SqlConnection connection = new SqlConnection(
                   connectionString))
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
                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = (Decimal)reader.GetSqlDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),

                });
            }

            // Call Close when done reading.
            reader.Close();
        }

        return _result;

    }
    public void AddPhone(Phone input)
    {
        Phone _result = new();
        string queryString = @$"INSERT INTO phones (Brand, Type, Description, Price,Stock)
                                VALUES ({input.Brand}, {input.Type}, {input.Description}.,{input.Stock}); ' ; ";
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.



            // Call Close when done reading.
            reader.Close();
        }



    }
}
