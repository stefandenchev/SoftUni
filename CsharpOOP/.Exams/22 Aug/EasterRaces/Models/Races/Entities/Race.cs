using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_LENGTH = 5;
        private const int MIN_LAPS = 1;

        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidName, value, MIN_LENGTH));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
            => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (this.drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(String.Format(
                    ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}