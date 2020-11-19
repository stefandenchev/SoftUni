using _07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; }
        public MissionStateEnum State { get;  }

        void CompleteMission();

    }
}