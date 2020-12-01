using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        CarRepository carRepository;
        DriverRepository driverRepository;
        RaceRepository raceRepository;

        private const int MIN_DRIVERS = 3;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            var driver = new Driver(driverName);

            if (this.driverRepository.Models.Any(x => x.Name == driverName))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.DriversExists, driverName));
            }

            this.driverRepository.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (this.carRepository.Models.Any(x => x.Model == model && x.HorsePower == horsePower))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.CarExists, model));
            }

            this.carRepository.Add(car);
            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.raceRepository.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.RaceExists, name));
            }

            this.raceRepository.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            ICar car = this.carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            IRace race = this.raceRepository.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.DriverNotFound, driverName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < MIN_DRIVERS)
            {
                throw new InvalidOperationException(String.Format(
                   ExceptionMessages.RaceInvalid, raceName, MIN_DRIVERS));
            }

            var participants = race.Drivers.OrderByDescending
                (x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(String.Format(OutputMessages.DriverFirstPosition, participants[0].Name, raceName))
                .AppendLine(String.Format(OutputMessages.DriverSecondPosition, participants[1].Name, raceName))
                .AppendLine(String.Format(OutputMessages.DriverThirdPosition, participants[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}