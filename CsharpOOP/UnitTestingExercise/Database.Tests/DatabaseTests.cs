using NUnit.Framework;
using System.Linq;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database();

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, expectedResult);

        }

        [Test]
        public void ConstructorShouldThrowExceptionIfThereAreNo16Elements()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database database = new Database();

            var expectedResult = 10;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, expectedResult);

        }

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database database = new Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedResult = 5;
            var actualResult = allElements[10];

            var expectedCount = 11;
            var actualCount = database.Count;



            Assert.AreEqual(expectedResult, expectedResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreAbove16()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(10));
        }

        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingElementAtLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database database = new Database(numbers);

            //Act
            database.Remove();

            //Assert
            var expectedResult = 9;
            var actualResult = database.Fetch()[8];

            var expectedCount = 9;
            var actualCount = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database database = new Database();

            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove());
        }

        /*-> same as previous
        public void Test() 
            => Assert.Throws<InvalidOperationException>(() =>
             new Database.Database().Remove());*/

        [Test]
        public void FetchShouldReturnAllElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database database = new Database(numbers);

            //Act
            var allItems = database.Fetch();

            //Assert
            int[] expectedValue = { 1, 2, 3, 4, 5 };

            Assert.AreEqual(expectedValue, allItems);
        }
    }
}