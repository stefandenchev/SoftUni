using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            PalindromeCheck(number);

            while (number != "END")
            {
                Console.WriteLine(PalindromeCheck(number).ToString().ToLower());
                number = Console.ReadLine();
            }
        }
        static bool PalindromeCheck(string number)
        {
            var numberReverse = number.Reverse().ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                if (!(numberReverse[i] == number[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
