using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                if (input.Contains("TakeOdd"))
                {
                    StringBuilder oddChars = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        oddChars.Append(password[i]);
                    }
                    password = oddChars.ToString();
                    Console.WriteLine(password);
                }

                else if (input.Contains("Cut"))
                {
                    var elements = input.Split();
                    int index = int.Parse(elements[1]);
                    int length = int.Parse(elements[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }

                else if (input.Contains("Substitute"))
                {
                    var elements = input.Split();
                    string substring = elements[1];
                    string substitute = elements[2];
                    if (password.IndexOf(substring) >= 0)
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}