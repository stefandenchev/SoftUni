﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        const string SqlConnectionString =
            @"Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var minionsQuery = "SELECT Name FROM Minions";

            using var selectCommand = new SqlCommand(minionsQuery, connection);
            using (var reader = selectCommand.ExecuteReader())
            {
                var minions = new List<string>();
                while (reader.Read())
                {
                    minions.Add((string)reader[0]);
                }

                int counter = 0;
                for (int i = 0; i < minions.Count/ 2; i++)
                {
                    Console.WriteLine(minions[0 + counter]);
                    Console.WriteLine(minions[minions.Count - 1 - counter]);
                    counter++;
                }

                if (minions.Count % 2 != 0)
                {
                    Console.WriteLine(minions[minions.Count / 2]);
                }
            }

        }
    }
}
