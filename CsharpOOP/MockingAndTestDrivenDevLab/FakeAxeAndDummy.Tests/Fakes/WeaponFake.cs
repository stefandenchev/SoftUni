using FakeAxeAndDummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests.Fakes
{
    public class WeaponFake : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(IAttackable target)
        {

        }
    }
}