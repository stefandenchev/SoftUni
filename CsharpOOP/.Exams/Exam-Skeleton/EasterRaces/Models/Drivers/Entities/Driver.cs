using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
/*        private ICar car;
        private int numberOfWins;
        private bool canParticipate;*/

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(name) || name.Length < 5)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car { get; set; }

        public int NumberOfWins { get; set; }

        public bool CanParticipate => this.Car != null;
       
        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}