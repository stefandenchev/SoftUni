using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string line1;

            while ((line1 = Console.ReadLine()) != "Beast!")
            {
                var elements = Console.ReadLine().Split();
                string name = elements[0];
                int age = int.Parse(elements[1]);
                string gender = null;

                if (elements.Length >= 3)
                {
                    gender = elements[2];
                }

                Animal animal = null;

                switch (line1)
                {
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;

                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;

                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;

                    case "Kitten":
                        animal = new Kitten(name, age, gender);
                        break;

                    case "Tomcat":
                        animal = new Tomcat(name, age, gender);
                        break;

                    default:
                        throw new ArgumentException("Invalid input!");
                }

                animals.Add(animal);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}