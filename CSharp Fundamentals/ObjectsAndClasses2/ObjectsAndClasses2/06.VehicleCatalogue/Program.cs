using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            /*double truckCount = 0;
            double carCount = 0;
            double truckPower = 0;
            double carPower = 0;*/

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] elements = command.Split();

                string type = elements[0].ToLower();
                string model = elements[1];
                string color = elements[2].ToLower();
                int horsePower = int.Parse(elements[3]);

                /* if (typeLow == "truck")
                 {
                     truckCount++;
                     truckPower += int.Parse(horsepower);
                 }
                 else
                 {
                     carCount++;
                     carPower += int.Parse(horsepower);
                 }*/


                // string type = typeLow.Substring(0, 1).ToUpper() + typeLow.Substring(1);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(vehicle);

                command = Console.ReadLine();

            }

            string secondCommand = Console.ReadLine();

            while (secondCommand != "Close the Catalogue")
            {
                foreach (var vehicle in vehicles.Where(x => x.Model == secondCommand))
                {
                    Console.WriteLine(vehicle.ToString());
                }
                secondCommand = Console.ReadLine();
            }

            /* Console.WriteLine($"Cars have average horsepower of: {carPower / carCount:f2}.");
             Console.WriteLine($"Trucks have average horsepower of: {truckPower / truckCount:f2}.");*/


            var onlyCars = vehicles.Where(x => x.Type == "car").ToList();
            var onlyTrucks = vehicles.Where(x => x.Type == "truck").ToList();
            double totalCarsHorsepower = 0;
            double totalTrucksHorsepower = 0;

            foreach (var car in onlyCars)
            {
                totalCarsHorsepower += car.Horsepower;
            }

            foreach (var truck in onlyTrucks)
            {
                totalTrucksHorsepower += truck.Horsepower;
            }

            double averageCarsHorsepower = totalCarsHorsepower / onlyCars.Count;
            double averageTrucksHorsepower = totalTrucksHorsepower / onlyTrucks.Count;

            if (onlyCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }


    }
}

public class Vehicle
{
    public Vehicle(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }


    public override string ToString()
    {
        /*StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Type: {Type}");
        sb.AppendLine($"Model: {Model}");
        sb.AppendLine($"Color: {Color}");
        sb.AppendLine($"Horsepower: {Horsepower}");


        return sb.ToString().TrimEnd();*/

        string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                            $"Model: {this.Model}{Environment.NewLine}" +
                            $"Color: {this.Color}{Environment.NewLine}" +
                            $"Horsepower: {this.Horsepower}";

        return vehicleStr;
    }
}

