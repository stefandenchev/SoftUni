using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _09._IncreaseAgeStoredProcedure
{
    class Program
    {
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            string procQuery = @"EXEC usp_GetOlder @id";
            using var command = new SqlCommand(procQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            using var selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@id", id);
            using var reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }


        }
    }
}