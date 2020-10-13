using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            this.ExistComputer(computerId);

            IComponent component;

            if (this.computers.Any(c => c.Components.Any(x => x.Id == id)))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            this.components.Add(component);
            this.computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            this.ExistComputer(computerId);

            IPeripheral peripheral;

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            this.peripherals.Add(peripheral);
            this.computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            throw new NotImplementedException();
        }

        public string BuyComputer(int id)
        {
            this.ExistComputer(id);

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            throw new NotImplementedException();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.ExistComputer(computerId);

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(component);

            this.computers
                .FirstOrDefault(x => x.Id == computerId)
                .RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.ExistComputer(computerId);

            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            this.computers
                .FirstOrDefault(x => x.Id == computerId)
                .RemoveComponent(peripheralType);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private void ExistComputer(int id)
        {
            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
