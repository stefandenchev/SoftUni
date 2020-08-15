using System;
using System.Text;

namespace _01.EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Complete")
            {
                var elements = input.Split();
                var command = elements[0];

                if (command.Contains("Make"))
                {
                    var size = elements[1];
                    if (size.Contains("Upper"))
                    {
                        email = email.ToUpper();
                    }
                    else
                    {
                        email = email.ToLower();
                    }
                    Console.WriteLine(email);
                }

                if (command.Contains("GetDomain"))
                {
                    var count = int.Parse(elements[1]);
                    string substring = email.Substring(email.Length - count, count);
                    Console.WriteLine(substring);
                }

                if (command.Contains("GetUsername"))
                {
                    if (email.Contains("@"))
                    {
                        int index = email.IndexOf('@');
                        string substring = email.Substring(0, index);
                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }

                if (command.Contains("Replace"))
                {
                    var ch = char.Parse(elements[1]);
                    email = email.Replace(ch, '-');
                    Console.WriteLine(email);
                }

                if (command.Contains("Encrypt"))
                {
                    var charArr = email.ToCharArray();
                    foreach (char ch in charArr)
                    {
                        Console.Write((int)ch + " ");
                    }
                    Console.WriteLine();
                }
                input = Console.ReadLine();
            }
        }
    }
}