using _07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; }

        public MissionStateEnum State { get; set; }

        public void CompleteMission(string codeName)
        {
            this.State = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
