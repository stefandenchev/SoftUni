using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Ivan", 10, 10)]
        [TestCase("Ivan", 20, 0)]
        public void WarriorConstructorShouldSetDataProperly
            (string name, int dmg, int hp)
        {
            Warrior warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);

        }

        [Test]
        [TestCase("", 10, 22)]
        [TestCase(" ", 50, 60)]
        [TestCase(null, 80, 90)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidDataIsPassed
            (string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase("Stoyan", 0, 22)]
        [TestCase("Niki", -10, 60)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidDamageIsPassed
            (string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase("Stoyan", -1, 22)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidHpIsPassed
            (string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, dmg, hp));
        }


    }
}