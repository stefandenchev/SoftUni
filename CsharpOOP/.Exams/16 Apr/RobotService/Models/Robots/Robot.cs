using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public string Name { get; set; }
        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value > MAX_VALUE || value < MIN_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }
        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value > MAX_VALUE || value < MIN_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {Name} - " +
                $"Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
