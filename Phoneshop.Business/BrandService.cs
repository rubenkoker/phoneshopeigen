using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Phoneshop.Business;

public class BrandService : IBrandservice
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    //public void ForceBrandExists(Brand brand);
    public void InsertBrand(Phone input)
    {
        string BrandQueryString = @$"INSERT INTO Brands (Name)
  VALUES('{input.Brand.Name}')";
        Debug.WriteLine("yee" + BrandQueryString);
        using (SqlConnection connection = new SqlConnection(
              _connectionString))
        {
            SqlCommand InsertBrandcommand = new SqlCommand(BrandQueryString, connection);
            InsertBrandcommand.Connection.Open();
            int _commandresult = InsertBrandcommand.ExecuteNonQuery();
            Debug.WriteLine(BrandQueryString);

        }
    }

    public bool DoesBrandExist(string CheckQuery, bool BrandExists)
    {
        using (SqlConnection connection = new SqlConnection(
                                   _connectionString))
        {
            SqlCommand getIDcommand = new SqlCommand(CheckQuery, connection);
            getIDcommand.Connection.Open();
            var _commandresult = getIDcommand.ExecuteReader();
            Debug.WriteLine(_commandresult);
            // Call Read before accessing data.

            // Call Close when done reading.

            if (_commandresult.Read())
            {
                BrandExists = true;
            }
        }

        return BrandExists;
    }
}