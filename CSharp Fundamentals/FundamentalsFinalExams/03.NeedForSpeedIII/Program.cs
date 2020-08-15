using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var elements = input.Split("|");

                var name = elements[0];
                var mileage = int.Parse(elements[1]);
                var fuel = int.Parse(elements[2]);
                Car car = new Car() { Mileage = mileage, Fuel = fuel };

                cars.Add(name, car);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                var elements = command.Split(" : ");
                if (command.Contains("Drive"))
                {
                    var car = elements[1];
                    var distance = int.Parse(elements[2]);
                    var fuel = int.Parse(elements[3]);

                    if (cars[car].Fuel - fuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Fuel -= fuel;
                        cars[car].Mileage += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[car].Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                    }
                }

                if (command.Contains("Refuel"))
                {
                    var car = elements[1];
                    var fuel = int.Parse(elements[2]);

                    if (cars[car].Fuel + fuel > 75)
                    {
                        fuel = 75 - cars[car].Fuel;
                    }
                    cars[car].Fuel += fuel;
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }

                if (command.Contains("Revert"))
                {
                    var car = elements[1];
                    var kilometers = int.Parse(elements[2]);

                    if (cars[car].Mileage - kilometers < 10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        cars[car].Mileage -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }

                command = Console.ReadLine();
            }

            var sortedCars = cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key);

            foreach (var car in sortedCars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }

        }
    }
}