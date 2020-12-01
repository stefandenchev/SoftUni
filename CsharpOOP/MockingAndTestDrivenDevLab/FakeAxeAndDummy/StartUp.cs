using FakeAxeAndDummy.Contracts;
using Moq;

public class StartUp
{
    public static void Main(string[] args)
    {
        Mock<IAttackable> target = new Mock<IAttackable>();
        target.Setup(t => t.GiveExperience()).Returns(20);
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        Hero hero = new Hero("Pesho", weapon.Object);

        int exp = target.Object.GiveExperience();
        System.Console.WriteLine(exp);
    }
}