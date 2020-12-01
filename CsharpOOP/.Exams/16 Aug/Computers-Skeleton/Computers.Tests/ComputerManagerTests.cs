using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computers;
        Computer goodComputer;
        Computer goodComputer2;
        Computer nullComputer;

        [SetUp]
        public void Setup()
        {
            this.computers = new ComputerManager();
            goodComputer = new Computer("Lenovo", "Legion", 1000);
            goodComputer2 = new Computer("Lenovo", "Thinkpad", 650);
            //nullComputer = new Computer(null, "Legion", 1000);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(this.computers.Count, 0);
        }

        [Test]
        public void AddComputerShouldWorkCorrectly()
        {
            this.computers.AddComputer(goodComputer);
            Assert.AreEqual(this.computers.Count, 1);
        }

        [Test]
        public void AddComputerShouldReturnExceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.computers.AddComputer(nullComputer));
        }

        [Test]
        public void AddComputerShouldReturnExceptionWhenComputerExists()
        {
            this.computers.AddComputer(goodComputer);

            Assert.Throws<ArgumentException>(() =>
            this.computers.AddComputer(goodComputer));
        }

        [Test]
        public void RemoveComputerWorksProperly()
        {
            this.computers.AddComputer(goodComputer);
            this.computers.RemoveComputer("Lenovo", "Legion");
            Assert.AreEqual(this.computers.Count, 0);
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            this.computers.AddComputer(this.goodComputer);

            Assert.Throws<ArgumentNullException>(() => this.computers.RemoveComputer("Lenovo", null));
        }


        [Test]
        public void GetComputerWorksProperly()
        {
            this.computers.AddComputer(goodComputer);

            Computer newPC = this.computers.GetComputer("Lenovo", "Legion");
            
            Assert.AreEqual(goodComputer, newPC);
        }

        [Test]
        public void GetComputerReturnsExceptionIfComputerDoesntExist()
        {
            this.computers.AddComputer(goodComputer);

            Assert.Throws<ArgumentException>(() =>
            this.computers.GetComputer("Acer", "Predator"));
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkCorrectly()
        {
            this.computers.AddComputer(goodComputer);
            this.computers.AddComputer(new Computer("a", "a", 10));

            var exp = 1;
            Assert.AreEqual(exp, this.computers.GetComputersByManufacturer("a").Count);

        }


    }
}