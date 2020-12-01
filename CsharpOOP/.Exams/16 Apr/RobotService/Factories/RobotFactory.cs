using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Factories
{
    public class RobotFactory
    {
        public IRobot CreateRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == typeof(HouseholdRobot).Name)
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == typeof(PetRobot).Name)
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == typeof(WalkerRobot).Name)
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.InvalidRobotType, robotType));
            }

            return robot;
        }
    }
}
