using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{

    private readonly List<Phone> _phones = new()
    {

        new Phone()
        {
            Id = 1,
            Brand = "Huawei",
            Type = "P30",
            Description = "6.47\" FHD+ (2340x1080) OLED," +
        " Kirin 980 Octo-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz +4x Cortex-A55 1.8GHz)," +
        " 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android9.0 + EMUI 9.1",
            Price = 697,
            Stock = 32
        },
        new Phone()
        {
            Id = 2,
            Brand = "Samsung",
            Type = "Galaxy A52",
            Description = "64 megapixel camera," +
        " 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd)" +
        " Water- en stofbestendig(IP67)",
            Price = 399,
            Stock = 42
        },
        new Phone()
        {
            Id = 3,
            Brand = "Apple",
            Type = "IPhone 11",
            Description = "Met de dubbele camera schiet je in elke situatie een perfecte foto of video " +
        "De krachtige A13-chipset zorgt voor razendsnelle prestaties " +
        "Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen " +
        "Het toestel heeft een lange accuduur dankzij een energiezuinige processor",
            Price = 619,
            Stock = 54
        },
        new Phone()
        {
            Id = 4,
            Brand = "Google",
            Type = "Pixel 4a",
            Description = "12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm " +
        "128 GB opslaggeheugen 3140 mAh accucapaciteit",
            Price = 411,
            Stock = 58
        },
        new Phone()
        {
            Id = 5,
            Brand = "Xiaomi",
            Type = "Redmi Note 10 Pro",
            Description = "108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm " +
          "128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)",
            Price = 298,
            Stock = 91
        },
    };

    /// <summary>
    /// returns the phone corresponding to the ID
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Phone? GetPhoneById(int input)
    {

        return _phones.Where(s => s.Id == input).FirstOrDefault();
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
        if (input == "")
        {
            return null;
        }

        return (from t in _phones
                where
                t.Brand.Contains(input, StringComparison.CurrentCultureIgnoreCase) ||
                t.Description.Contains(input, StringComparison.CurrentCultureIgnoreCase) ||
                t.Type.Contains(input, StringComparison.CurrentCultureIgnoreCase)
                select t).ToList();
    }
}