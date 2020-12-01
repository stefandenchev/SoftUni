//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private readonly Person[] people =
        {
            new Person(23, "Stefan"),
            new Person(3, "Valeri")
        };

        private ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            db = new ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.db.Count, 2);
        }

        [Test]
        public void ConstructorShouldThrownExceptionWithMoreData()
        {
            var persons = new Person[17];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(100 + i, $"Person{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                this.db = new ExtendedDatabase(persons);
            });
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            Person person = new Person(8, "Ivan");
            db.Add(person);

            Assert.AreEqual(this.db.Count, 3);
        }

        [Test]
        public void AddShouldThrowExceptionWithMoreData()
        {
            for (int i = 2; i < 16; i++)
            {
                this.db.Add(new Person(100 + i, $"Person{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
                this.db.Add(new Person(458, "Gosho")));

        }

        [Test]
        public void AddOperationShouldThrowExceptionIfAddPersonWithSameUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.db.Add(new Person(123, "Stefan")));
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfAddPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.db.Add(new Person(23, "Krumcho")));
        }

        [Test]
        public void RemoveOperationShouldWorkCorrectly()
        {
            this.db.Remove();
            Assert.AreEqual(this.db.Count, 1);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfEmpty()
        {
            this.db.Remove();
            this.db.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            this.db.Remove());
        }

        [Test]
        [TestCase("Stefan")]
        public void FindByNameShouldWorkCorrectly(string name)
        {
            var found = this.db.FindByUsername(name);
            Assert.AreEqual(found, people[0]);
        }

        [Test]
        [TestCase(23)]
        public void FindByIdShouldWorkCorrectly(long id)
        {
            var found = this.db.FindById(id);
            Assert.AreEqual(found, people[0]);
        }

        [Test]
        public void FindOperationShouldThrowExceptionIfNameDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.db.FindByUsername("Kilimcho"));
        }

        [Test]
        public void FindOperationShouldThrowExceptionIfNameArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.db.FindByUsername(null));
        }

        [Test]
        public void FindOperationShouldThrowExceptionIfIdDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.db.FindById(1111));
        }

        [Test]
        public void FindOperationShouldThrowExceptionIfIdArgumentIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException >(() =>
            this.db.FindById(-1));
        }
    }
}