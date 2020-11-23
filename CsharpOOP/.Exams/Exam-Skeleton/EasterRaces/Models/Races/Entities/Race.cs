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
        private const int Default_Model_Symbol = 5;
        private const int Default_Less_Laps = 1;

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
            set
            {
                if (String.IsNullOrWhiteSpace(value) || name.Length < Default_Model_Symbol)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidName, value, Default_Model_Symbol));
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
            set
            {
                if (laps < Default_Less_Laps)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidNumberOfLaps, Default_Less_Laps));
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
            if (driver.CanParticipate == false)
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