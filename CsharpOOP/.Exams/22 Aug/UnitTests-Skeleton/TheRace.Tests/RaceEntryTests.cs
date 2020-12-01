using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry driver;


        [SetUp]
        public void Setup()
        {
            this.driver = new RaceEntry();
        }


        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(this.driver.Counter, 0);
        }

        [Test]
        public void AddDriverShouldWorkCorrectly()
        {
            UnitDriver driver = new UnitDriver("Stoicho", null);
            this.driver.AddDriver(driver);
            Assert.AreEqual(this.driver.Counter, 1);
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.driver.AddDriver(driver);
            });
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverAlreadyExists()
        {
            UnitDriver driver = new UnitDriver("Stoicho", null);
            this.driver.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
                this.driver.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldWorksCorrectly()
        {
            UnitCar car = new UnitCar("Mazda", 12, 23);
            UnitDriver driver = new UnitDriver("Stefancho", car);

            var result = this.driver.AddDriver(driver);

            Assert.AreEqual(this.driver.Counter, 1);
            Assert.AreEqual(result, $"Driver {driver.Name} added in race.");
        }

        [Test]
        public void CalculateHorsePowerShouldThrowExceptionIfRacersAreFewerThan2()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.driver.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateHorsePowerShouldWorkCorrectly()
        {
            UnitCar car = new UnitCar("Mazda", 12, 23);
            UnitDriver driver = new UnitDriver("Stefancho", car);

            UnitCar car2 = new UnitCar("Lambo", 16, 25);
            UnitDriver driver2 = new UnitDriver("Valeri", car2);

            this.driver.AddDriver(driver);
            this.driver.AddDriver(driver2);

            double expectedResult = (driver.Car.HorsePower + driver2.Car.HorsePower) / 2;
            double actualResult = this.driver.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}