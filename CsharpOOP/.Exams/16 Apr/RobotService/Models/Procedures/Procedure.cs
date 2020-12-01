using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected ICollection<IRobot> Robots { get; set; }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            foreach (IRobot robot in this.Robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name}" +
                    $" - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}