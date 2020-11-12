using _01.Vehicles.Common;
using _01.Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONS_INCR = 1.4;
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption =>
            base.FuelConsumption + FUEL_CONS_INCR;

        public override string DriveEmpty(double amount)
        {
            double fuelNeeded = amount * (FuelConsumption - FUEL_CONS_INCR);

            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }
    }
}
