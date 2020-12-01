using RobotService.Core.Contracts;
using RobotService.Factories;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        RobotFactory factory = new RobotFactory();
        //private IGarage garage;
        private IProcedure chip;
        private IProcedure techCheck;
        private IProcedure rest;
        private IProcedure work;
        private IProcedure charge;
        private IProcedure polish;

        public Controller()
        {
            this.garage = new Garage();
            this.chip = new Chip();
            this.techCheck = new TechCheck();
            this.rest = new Rest();
            this.work = new Work();
            this.charge = new Charge();
            this.polish = new Polish();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = factory.CreateRobot(robotType, name, energy, happiness, procedureTime);
            this.garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, name);           
        }
        public string Chip(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.chip.DoService(robot, procedureTime);

            return $"{robotName} had chip procedure";
        }
        public string TechCheck(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.techCheck.DoService(robot, procedureTime);

            return $"{robotName} had tech check procedure";
        }
        public string Rest(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.rest.DoService(robot, procedureTime);

            return $"{robotName} had rest procedure";
        }
        public string Work(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.work.DoService(robot, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.charge.DoService(robot, procedureTime);

            return $"{robotName} had charge procedure";
        }
        public string Polish(string robotName, int procedureTime)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.polish.DoService(robot, procedureTime);

            return $"{robotName} had polish procedure";
        }
        public string Sell(string robotName, string ownerName)
        {
            CheckRobotExistence(this.garage, robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
        }

        public string History(string procedureType)
        {
            if (procedureType == "Chip")
            {
                return this.chip.History();
            }
            else if (procedureType == "TechCheck")
            {
                return this.techCheck.History();
            }
            else if (procedureType == "Rest")
            {
                return this.rest.History();
            }
            else if (procedureType == "Work")
            {
                return this.work.History();
            }
            else if (procedureType == "Charge")
            {
                return this.charge.History();
            }
            else if (procedureType == "Polish")
            {
                return this.polish.History();
            }
            else
            {
                return null;
            }
        }

        public void CheckRobotExistence(Garage garage, string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.InexistingRobot, name));
            }
        }
    }
}