using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        SoldierCorpEnum SoldierCorpEnum { get; }
    }
}
