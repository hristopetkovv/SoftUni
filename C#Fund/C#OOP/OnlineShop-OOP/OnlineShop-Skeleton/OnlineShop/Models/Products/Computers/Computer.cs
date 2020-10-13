using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this.peripherals;

        public override double OverallPerformance 
        { 
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return (double)this.components.Sum(c => c.Price);
            }
        }

        public override decimal Price 
        {
            get => this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.components.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Component {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 && this.components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent componentToRemove = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.components.Count == 0 && this.components.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral peripheralToRemove = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component.GetType().Name}");
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral.GetType().Name}");

            }

            return base.ToString() + sb.ToString().TrimEnd();
        }
    }
}
