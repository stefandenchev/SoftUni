using Microsoft.Data.SqlClient;
using System;

namespace _06._RemoveVillain
{
    class Program
    {
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            int villainId = int.Parse(Console.ReadLine());

            string evilNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
            using var sqlCommand = new SqlCommand(evilNameQuery, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            var result = (string)sqlCommand.ExecuteScalar();

            if (result == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            var deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                               WHERE VillainId = @villainId";

            using var deleteMinionsVillainsCmd = new SqlCommand(deleteMinionsVillainsQuery, connection);
            deleteMinionsVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
            var affectedRows = deleteMinionsVillainsCmd.ExecuteNonQuery();

            var deleteVillainsQuery = @"DELETE FROM Villains
                                        WHERE Id = @villainId";

            using var deleteVillainsCmd = new SqlCommand(deleteVillainsQuery, connection);
            deleteVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
            deleteVillainsCmd.ExecuteNonQuery();

            Console.WriteLine($"{result} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");

        }
    }
}
