//using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeDependentValue()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorExists()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Stoyan", 10, 10);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            arena.Enroll(warrior));
        }

        [Test]
        public void EnrollShouldAddWarriorToCollection()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Stoyan", 10, 10);
            Warrior warrior2 = new Warrior("Kiro", 20, 50);
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            var expectedCount = 2;
            var exists1 = arena.Warriors.Any(x => x.Name == "Stoyan");
            var exists2 = arena.Warriors.Any(x => x.Name == "Kiro");

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.IsTrue(exists1);
            Assert.IsTrue(exists2);
        }

        [Test]
        [TestCase("Gosho", "Stoyan")]
        public void FightShouldThrowExceptionIfWarriorDoesntExist
            (string attacker, string defender)
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(attacker, defender));

            Warrior warrior = new Warrior(attacker, 10, 10);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(attacker, defender));
        }

        [Test]
        public void FightShouldWorkAsExpected()
        {
            Arena arena = new Arena();

            Warrior attacker = new Warrior("Stoyan", 10, 50);
            Warrior defender = new Warrior("Kiro", 10, 50);

            arena.Enroll(attacker);        
            arena.Enroll(defender);

            arena.Fight("Stoyan", "Kiro");

            var kiroHp = arena.Warriors.FirstOrDefault(x => x.Name == "Kiro").HP;
            var stoyanHp = arena.Warriors.FirstOrDefault(x => x.Name == "Stoyan").HP;

            Assert.AreEqual(kiroHp, 40);
            Assert.AreEqual(stoyanHp, 40);
        }
    }
}