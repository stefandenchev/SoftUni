using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }

        public MissionStateEnum State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == MissionStateEnum.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            this.State = MissionStateEnum.Finished;
        }

        private MissionStateEnum TryParseState(string stateStr)
        {
            MissionStateEnum state;
            bool parsed = Enum.TryParse<MissionStateEnum>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
