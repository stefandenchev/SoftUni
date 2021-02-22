using Microsoft.Data.SqlClient;
using System;

namespace _02._VillainNames
{
    class Program
    {
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                             GROUP BY v.Id, v.Name 
                               HAVING COUNT(mv.VillainId) > 3 
                             ORDER BY COUNT(mv.VillainId)";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
                
            }
        }
    }
}