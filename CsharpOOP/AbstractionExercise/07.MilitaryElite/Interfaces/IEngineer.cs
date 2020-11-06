using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
