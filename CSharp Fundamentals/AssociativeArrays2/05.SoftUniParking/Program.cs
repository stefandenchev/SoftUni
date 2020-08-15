using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var elements = input.Split();

                var command = elements[0];
                var user = elements[1];

                if (command == "register")
                {
                    var plate = elements[2];
                    if (!parkingLot.ContainsKey(user))
                    {
                        parkingLot.Add(user, plate);
                        Console.WriteLine($"{user} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingLot[user]}");
                    }
                }
                else
                {
                    if (!parkingLot.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parkingLot.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }
            foreach (var pair in parkingLot)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
