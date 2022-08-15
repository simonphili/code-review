using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL;

public class User_Service
{
    public static string connectionString = "Server=localhost;Database=myDataBase;User Id=sqlUsername;Password=sqlPassword;";

    private SqlCommand command;

    public static void createUser(string UserName)
    {
        string Password;
        var random = new Random();

        for (int i = 0; i < 6; i++)
        {
            var letter = random.Next(256);

            Password += letter;
        }

        string query = $"INSERT INTO dbo.Users (username,password) VALUES ({UserName},{Password})";

        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        try
        {
            command = new SqlCommand(queryString, connection);
            int result = command.ExecuteNonQuery();

            if (result < 0)
                Console.WriteLine("Error inserting data into Database!");
        }
        finally
        {
            connection.Close();
        }
    }
}
