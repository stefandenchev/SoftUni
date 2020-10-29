using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] elements = command.Split().ToArray();

                string name = elements[0];
                int age = int.Parse(elements[1]);
                string town = elements[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person comparedPerson = people[n - 1];

            int samePersonCount = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    samePersonCount++;
                }
            }

            if (samePersonCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notSamePersonCount = people.Count - samePersonCount;

                Console.WriteLine($"{samePersonCount} {notSamePersonCount} {people.Count}");
            }
        }
    }
}