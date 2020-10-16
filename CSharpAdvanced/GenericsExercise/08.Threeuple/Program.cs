using System;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];
            string town = firstLine[3];
            Threeuple<string, string, string> firstPerson = new Threeuple<string, string, string>(fullName, address, town);

            string[] secondLine = Console.ReadLine().Split();
            string name = secondLine[0];
            int beerAmount = int.Parse(secondLine[1]);
            string isDrunk = secondLine[2];
            bool drunk = false;
            if (isDrunk == "drunk")
            {
                drunk = true;
            }
            Threeuple<string, int, bool> secondPerson = new Threeuple<string, int, bool>(name, beerAmount, drunk);

            string[] thirdLine = Console.ReadLine().Split();
            string nameAgain = thirdLine[0];
            double balance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];
            Threeuple<string, double, string> thirdPerson = new Threeuple<string, double, string>(nameAgain, balance, bankName);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);
        }
    }
}