using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Phoneshop.Business;

public class BrandService : IBrandservice
{
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
    private readonly IRepository<Phone> repository;
    //public void ForceBrandExists(Brand brand);
    public void InsertBrand(Phone input)
    {
        repository.Create(input);


    }

    public bool DoesBrandExist(string Name)
    {
        using (SqlConnection connection = new SqlConnection(
                                   _connectionString))
        {
            string CheckQuery = $" SELECT Name FROM Brands WHERE NAME = ${Name}); ";
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