using _07.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName,
            decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.SoldierCorpEnum = this.TryParseCorps(corps);
        }

        public SoldierCorpEnum SoldierCorpEnum { get; private set; }

        private SoldierCorpEnum TryParseCorps(string corpsStr)
        {
            SoldierCorpEnum corps;
            bool parsed = Enum.TryParse<SoldierCorpEnum>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Corps: {this.SoldierCorpEnum.ToString()}";
        }
    }
}