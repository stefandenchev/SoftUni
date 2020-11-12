using _01.Vehicles.Common;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {
            
        }
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity,
            double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}