using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                var elements = command.Split(":|:");

                if (command.Contains("InsertSpace"))
                {
                    int index = int.Parse(elements[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }

                if (command.Contains("Reverse"))
                {
                    var substring = elements[1];
                    var position = message.IndexOf(substring);
                    if (message.Contains(substring))
                    {
                        /* var firstPart = message.Substring(0, position);
                         var secondPart = message.Substring(position, substring.Length);

                         var charArr = secondPart.ToCharArray();
                         Array.Reverse(charArr);
                         string reversed = new string(charArr);
                         secondPart = reversed;

                         var thirdPart = message.Substring(position + substring.Length);
                         message = firstPart + thirdPart + secondPart;*/

                        message = message.Remove(position, substring.Length);
                        var reversed = new string(substring.Reverse().ToArray());
                        message += reversed;

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                if (command.Contains("ChangeAll"))
                {
                    var substring = elements[1];
                    var replacement = elements[2];

                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }


                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}