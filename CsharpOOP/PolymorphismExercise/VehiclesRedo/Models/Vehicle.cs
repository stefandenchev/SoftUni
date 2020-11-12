using System;
using System.Collections.Generic;
using System.Text;
using VehiclesRedo.Interfaces;

namespace VehiclesRedo.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const string SUCC_DRIVE = "{0} travelled {1} km";
        private const string UNSUCC_DRIVE = "{0} needs refueling";

        private double fuelQuantity;
        private double fuelConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }
        public string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;
            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;
                return String.Format(SUCC_DRIVE, this.GetType().Name, distance);
            }
            else
            {
                return String.Format(UNSUCC_DRIVE, this.GetType().Name);
            }


        }
            
        public virtual void Refuel(double amount)
        {
            this.fuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity}";
        }
    }
}
