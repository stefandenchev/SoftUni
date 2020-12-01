using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        private ICollection<IComputer> computers;
        public Controller()
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.computers = new List<IComputer>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent component = null;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            this.EnsureComponentIdIsUnique(id);

            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;
            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }          
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0)
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer computer = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            string result = computer.ToString();
            this.computers.Remove(computer);

            return result;
        }

        public string GetComputerData(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computer.RemoveComponent(componentType);
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component != null)
            {
                this.components.Remove(component);
            }

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computer.RemovePeripheral(peripheralType);
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral != null)
            {
                this.peripherals.Remove(peripheral);
            }

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public void CheckComputerId(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private void EnsureComponentIdIsUnique(int id)
        {
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
        }
    }
}
