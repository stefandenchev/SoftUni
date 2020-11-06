using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var elements = input.Split();
                var name = elements[0];
                var country = elements[1];
                var age = int.Parse(elements[2]);

                /*IPerson citizen = new Citizen(name, country, age);
                IResident citizen2 = new Citizen(name, country, age);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizen2.GetName());*/

                Citizen cz = new Citizen(name, country, age);
                Console.WriteLine(((IPerson)cz).GetName());
                Console.WriteLine(((IResident)cz).GetName());
            }
        }
    }
}
