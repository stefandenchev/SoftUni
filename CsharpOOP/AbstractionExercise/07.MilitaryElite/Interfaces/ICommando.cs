using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}
