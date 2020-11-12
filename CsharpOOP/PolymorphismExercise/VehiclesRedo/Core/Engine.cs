using System;
using VehiclesRedo.Models;

namespace VehiclesRedo.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = ProcesVehicleInfo();
            Vehicle truck = ProcesVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                string command = elements[0];
                string vehicleType = elements[1];
                double amount = double.Parse(elements[2]);

                try
                {
                    if (vehicleType == "Car")
                    {
                        if (command == "Drive")
                        {
                            this.Drive(car, amount);
                        }
                        else if (command == "Refuel")
                        {
                            this.Refuel(car, amount);
                        }
                    }

                    else if (vehicleType == "Truck")
                    {
                        if (command == "Drive")
                        {
                            this.Drive(truck, amount);
                        }
                        else if (command == "Refuel")
                        {
                            this.Refuel(truck, amount);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }
        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }

        private Vehicle ProcesVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split();

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle currVehicle = this.vehicleFactory.Create(vehicleType, fuelQuantity, fuelConsumption);

            return currVehicle;
        }
    }
}