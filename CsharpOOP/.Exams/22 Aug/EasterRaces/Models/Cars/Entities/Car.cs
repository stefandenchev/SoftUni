using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MIN_LENGTH = 4;
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            MinHorsePower = minHorsePower;
            MaxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidModel, value, MIN_LENGTH));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public int MinHorsePower { get; }

        public int MaxHorsePower { get; }

        public double CalculateRacePoints(int laps)
            => this.CubicCentimeters / this.HorsePower * laps;
    }
}