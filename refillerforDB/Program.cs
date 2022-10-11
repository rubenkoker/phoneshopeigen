// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;
string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
Console.WriteLine("Hello, World!");
SqlCommandPrepareEx(_connectionString);
static void SqlCommandPrepareEx(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlCommand command = new SqlCommand(null, connection);

        // Create and prepare an SQL statement.
        command.CommandText =
            "INSERT INTO  Phones(Brands, Type, Description, Price,Stock) " +
            "VALUES (@id,@Type, @desc ,@Price,@Stock)";
        SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
        SqlParameter typeParam = new SqlParameter("@type", SqlDbType.VarChar, 100);
        SqlParameter PriceParam = new SqlParameter("@Price", SqlDbType.Int, 0);
        SqlParameter stockParam = new SqlParameter("@Stock", SqlDbType.Int, 0);
        SqlParameter descParam =
            new SqlParameter("@desc", SqlDbType.Text, 100);
        idParam.Value = 20;
        descParam.Value = "First Region";
        command.Parameters.Add(idParam);
        command.Parameters.Add(descParam);
        command.Parameters.Add(typeParam);
        command.Parameters.Add(PriceParam);
        command.Parameters.Add(stockParam);
        // Call Prepare after setting the Commandtext and Parameters.
        command.Prepare();
        command.ExecuteNonQuery();

        // Change parameter values and call ExecuteNonQuery.
        command.Parameters[0].Value = 21;
        command.Parameters[1].Value = "Second Region";
        command.ExecuteNonQuery();
    }
}