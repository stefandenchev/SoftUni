using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08._IncreaseMinionAge
{
    class Program
    {
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var updateMinionsQuery = @"UPDATE Minions
                                       SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                       WHERE Id = @Id";


            foreach (var id in minionIds)
            {
                using var sqlCommand = new SqlCommand(updateMinionsQuery, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

            var selectMinionsQuery = @"SELECT Name, Age FROM Minions";

            using var selectCommand = new SqlCommand(selectMinionsQuery, connection);

            using var reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }


        }
    }
}