using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models.Contracts
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; }
        public virtual double TankCapacity { get; }

        public virtual string Drive(double amount)
        {
            double fuelNeeded = amount * FuelConsumption;

            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }

        public virtual string DriveEmpty(double amount)
        {
            return null;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NegFuel);
            }

            else if (amount > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.TooMuchFuel, amount));
            }

            this.FuelQuantity += amount;



        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
