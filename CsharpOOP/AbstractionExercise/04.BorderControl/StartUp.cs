using _04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> entities = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            string input;

            for (int i = 0; i < n; i++)
            {
                IBuyer entity;
                input = Console.ReadLine();
                var elements = input.Split();
                if (elements.Length == 4)
                {
                    string name = elements[0];
                    int age = int.Parse(elements[1]);
                    string id = elements[2];
                    string birthdate = elements[3];

                    if (entities.Any(x => x.Name == name))
                    {
                        continue;
                    }
                    else
                    {
                        entity = new Citizen(name, age, id, birthdate);
                        entities.Add(entity);
                    }
                }
                else
                {
                    string name = elements[0];
                    int age = int.Parse(elements[1]);
                    string group = elements[2];

                    if (entities.Any(x => x.Name == name))
                    {
                        continue;
                    }
                    else
                    {
                        entity = new Rebel(name, age, group);
                        entities.Add(entity);
                    }                   
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                if (entities.Any(x => x.Name == input))
                {
                    var entity = entities.FirstOrDefault(x => x.Name == input);
                    entity.BuyFood();
                }
            }

            int totalFood = 0;
            foreach (var human in entities)
            {
                totalFood += human.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}