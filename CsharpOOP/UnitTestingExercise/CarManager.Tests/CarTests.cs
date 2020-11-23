using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf", 10, 100)]
        [TestCase("BMW", "3", 20, 200)]
        public void CarConstructorShouldSetAllDataCorrectly(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            // Arrange / Act
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity);

            //Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty
            (string make)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, "model", 10, 10));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty
            (string model)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", model, 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsBelowOrEqualToZero
            (double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", "model", fuelConsumption, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsBelowOrEqualToZero
            (double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionWhenPassedValueIsBelowOrEqualToZero
            (double value)
        {
            Car car = new Car("VW", "Golf", 10, 100);
            Assert.Throws<ArgumentException>(() =>
                car.Refuel(value));
        }

        [Test]
        [TestCase(100, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldWorkAsExpected
            (double capacity, double fuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("VW", "Golf", 10, capacity);

            //Act
            car.Refuel(fuel);

            //Assert
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 50, 505)]
        [TestCase(15, 30, 505)]
        [TestCase(15, 0, 1)]
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnough
            (double fuelConsumption, double refuel, double km)
        {
            //Arrange
            Car car = new Car("VW", "Golf", 10, 100);
            car.Refuel(50);

            //Assert Act
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(505));
        }

        [Test]
        [TestCase(10, 100, 50, 95)]
        public void DriveShouldReduceFuelBasedOnDrivenKm
            (double fuelConsumption, double fuel, double km, double fuelAmountLeft)
        {
            //Arrange
            Car car = new Car("VW", "Golf", fuelConsumption, 100);
            car.Refuel(fuel);

            //Act
            car.Drive(km);

            //Assert
            var expectedValue = fuelAmountLeft;
            var actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}