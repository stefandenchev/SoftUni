using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _03._MinionNames
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

            string villianNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";

            using var command = new SqlCommand(villianNameQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            var result = command.ExecuteScalar();

            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villian: {result}");

                using var minionCommand = new SqlCommand(minionsQuery, connection);
                minionCommand.Parameters.AddWithValue("@Id", id);
                using var reader = minionCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                }
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                }
            }

        }
    }
}
