using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var engine = new Engine();
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                engine.Model = elements[0];
                engine.Power = int.Parse(elements[1]);

                if (elements.Length == 3)
                {
                    if (Char.IsDigit(elements[2], 0))
                    {
                        engine.Displacement = elements[2];
                    }
                    else
                    {
                        engine.Efficiency = elements[2];
                    }
                }
                if (elements.Length == 4)
                {
                    engine.Displacement = elements[2];
                    engine.Efficiency = elements[3];
                }


                engines.Add(engine);
            }

            var cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var car = new Car();
                var input = Console.ReadLine();
                var elements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                car.Model = elements[0];
                car.Engine = engines.Where(x => x.Model == elements[1]).FirstOrDefault();

                if (elements.Length == 3)
                {
                    if (Char.IsDigit(elements[2], 0))
                    {
                        car.Weight = elements[2];
                    }
                    else
                    {
                        car.Color = elements[2];
                    }
                }
                if (elements.Length == 4)
                {
                    car.Weight = elements[2];
                    car.Color = elements[3];
                }


                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");

            }
        }
    }
}