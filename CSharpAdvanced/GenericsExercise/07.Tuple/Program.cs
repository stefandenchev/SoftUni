using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split();
            string fullname = $"{firstTokens[0]} {firstTokens[1]}";
            string address = firstTokens[2];
            Tuple<string, string> firstPersonInfo = new Tuple<string, string>(fullname, address);

            string[] secondTokens = Console.ReadLine().Split();
            string name = secondTokens[0];
            int litersOfBeer = int.Parse(secondTokens[1]);
            Tuple<string, int> secondPersonInfo= new Tuple<string, int>(name, litersOfBeer);

            string[] thirdTokens = Console.ReadLine().Split();
            int intNum = int.Parse(thirdTokens[0]);
            double doubleNum = double.Parse(thirdTokens[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstPersonInfo);
            Console.WriteLine(secondPersonInfo);
            Console.WriteLine(numbers);
        }
    }
}