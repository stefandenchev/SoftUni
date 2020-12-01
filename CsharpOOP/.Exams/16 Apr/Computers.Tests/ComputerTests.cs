namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        Computer computer;
        Part GPU;
        Part CPU;
        Part nullPart;
        [SetUp]
        public void Setup()
        {
            computer = new Computer("AORUS");
            GPU = new Part("EVGA", 1000);
            CPU = new Part("Intel i7", 500);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void CheckIfNameSetterThrowsException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            computer = new Computer(name));
        }

        [Test]
        public void CheckIfNameSetterWorksCorrectly()
        {
            this.computer.AddPart(GPU);
            var part = this.computer.Parts.FirstOrDefault(x => x.Name == "EVGA");

            Assert.AreEqual("EVGA", part.Name);
        }

        [Test]
        public void CheckIfAddPartSetterThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.computer.AddPart(nullPart));
        }

        [Test]
        public void CheckIfAddPartWorksCorrectly()
        {
            computer.AddPart(GPU);
            Assert.AreEqual(computer.Parts.Count, 1);
        }

        [Test]
        public void CheckIfRemovePartWorksCorrectly()
        {
            computer.AddPart(GPU);
            computer.RemovePart(GPU);
            Assert.AreEqual(computer.Parts.Count, 0);
        }

        [Test]
        public void CheckIfTotalPriceWorksCorrectly()
        {
            computer.AddPart(GPU);
            computer.AddPart(CPU);

            int expectedPrice = 1500;

            Assert.AreEqual(computer.TotalPrice, expectedPrice);
        }

        [Test]
        public void RemovePartShouldReturnFalseWhenNotRemoveSuccessfully()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);

            Assert.AreEqual(this.computer.Parts.Count, 1);

            var result = this.computer.RemovePart(part1);

            Assert.AreEqual(this.computer.Parts.Count, 1);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void GetPartShouldWorkCorrectly()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            var result = this.computer.GetPart(part.Name);

            Assert.AreSame(result, part);
        }
    }
}