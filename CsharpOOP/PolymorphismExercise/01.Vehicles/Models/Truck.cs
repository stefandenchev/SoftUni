using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models.Contracts
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONS_INCR = 1.6;
        private const double REFUEL_SUCC_COEFF = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => 
            base.FuelConsumption + FUEL_CONS_INCR;

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NegFuel);
            }

            else
            {
                double totalFuel = base.FuelQuantity + (amount * REFUEL_SUCC_COEFF);
                if (totalFuel > base.TankCapacity)
                {
                    throw new InvalidOperationException(String.Format(
                    ExceptionMessages.TooMuchFuel, amount));
                }
                else
                {
                    base.FuelQuantity += (amount * REFUEL_SUCC_COEFF);
                }
            }
        }
    }
}