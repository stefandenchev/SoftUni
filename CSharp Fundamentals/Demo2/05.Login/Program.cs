using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = new string(name.ToCharArray().Reverse().ToArray());
            
            int counter = 0;

            while (true)
            {
                if (counter == 4)
                {
                    Console.WriteLine($"User {name} blocked!");
                    break;
                }
                string input = Console.ReadLine();
                if (input == pass)
                {
                    Console.WriteLine($"User {name} logged in.");
                    break;
                }
                else
                {
                    if (counter == 3)
                    {
                        counter++;
                        continue;
                    }
                        Console.WriteLine("Incorrect password. Try again.");
                    counter++;
                    continue;
                }
            }
        }
    }
}