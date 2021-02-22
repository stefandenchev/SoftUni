using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _04._AddMinion
{
    class Program
    {
        // a bit extended
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var minionInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var minionsInfo = minionInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var villainInfo = villainInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string result = AddMinionToDb(connection, minionsInfo, villainInfo);
            Console.WriteLine(result);
        }

        private static string AddMinionToDb(SqlConnection connection, string[] minionInfo, string[] villainInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionInfo[0];
            string minionAge = minionInfo[1];
            string minionTown = minionInfo[2];

            string villainName = villainInfo[0];

            string townId = EnsureTownExists(connection, minionTown, output);
            string villainId = EnsureVillainExists(connection, villainName, output);

            string insertMinionQueryText = @"INSERT INTO MINIONS([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId)";
            using SqlCommand insertMinionCmd = new SqlCommand(insertMinionQueryText, connection);
            insertMinionCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionAge),
                new SqlParameter("@townId", townId)
            });

            insertMinionCmd.ExecuteNonQuery();

            string getMinionIdQueryText = "@SELECT Id FROM Minions WHERE [Name] = @minionName";
            using SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQueryText, connection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCmd.ExecuteScalar().ToString();

            string insertMinionMappingQueryText = "@INSERT INTO MinionsVillains(MinionId, VallainId) VALUES (@minionId, @villainId)";
            using SqlCommand insertMinionMappingCmd = new SqlCommand(insertMinionMappingQueryText, connection);
            insertMinionMappingCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionId", minionId),
                new SqlParameter("@villainId", villainId),
            });

            insertMinionCmd.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
            return output.ToString().TrimEnd();
        }

        private static string EnsureVillainExists(SqlConnection connection, string villainName, StringBuilder output)
        {
            string getVillainIdQueryText = @"SELECT Id FROM Villains WHERE Name = @name";
            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQueryText, connection);
            getVillainIdCmd.Parameters.AddWithValue("@name", villainName);

            string villainId = getVillainIdCmd.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getFactorIdQueryText = @"SELECT Id FROM EvilnessFactors WHERE [Name] = 'Evil'";
                using SqlCommand getFactorIdCmd = new SqlCommand(getFactorIdQueryText, connection);

                string factorId = getFactorIdCmd.ExecuteScalar()?.ToString();

                string insertVillainQueryText = @"INSERT INTO Villains([Name], EvilnessFactorId) VALUES (@villainName, @factorId)";
                using SqlCommand insertVillainCmd = new SqlCommand(insertVillainQueryText, connection);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCmd.Parameters.AddWithValue("@factorId", factorId);

                insertVillainCmd.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection connection, string minionTown, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns WHERE Name = @townName";
            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQueryText, connection);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = @"INSERT INTO TOWNS([Name], CountryCode) VALUES (@townName, 1)";
                using SqlCommand insertTownCmd = new SqlCommand(insertTownQueryText, connection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();

                townId = getTownIdCmd.ExecuteScalar().ToString();
                output.AppendLine($"Town {minionTown} was added to the database");
            }
            return townId;
        }
    }
}