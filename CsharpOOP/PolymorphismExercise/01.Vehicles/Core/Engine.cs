using _01.Vehicles.Factories;
using _01.Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Core
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
            Vehicle car = this.ProcesVehicleInfo();
            Vehicle truck = this.ProcesVehicleInfo();
            Vehicle bus = this.ProcesVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double arg = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, arg);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, arg);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        this.DriveEmpty(bus, arg);
                    }

                }

                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }
        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private void DriveEmpty(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.DriveEmpty(kilometers));
        }

        private Vehicle ProcesVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split();

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            Vehicle currVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return currVehicle;
        }
    }
}