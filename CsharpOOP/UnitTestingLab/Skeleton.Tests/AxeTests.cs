using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    [TestCase(45, 45, 50, 31, 30)]
    public void WeaponShouldLoseDurabilityAfterAttack(int health, int exp,
        int attack, int durability, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        var actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void
        AttackShouldThrowInvalidOperationExceptionWhenAxeDurabilityIsBelowZero()
    {
        //Arrange
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() =>
        axe.Attack(dummy));

        /*Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message
            (""));*/
    }
}