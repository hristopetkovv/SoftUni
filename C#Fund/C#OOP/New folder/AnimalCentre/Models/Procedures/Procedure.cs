﻿namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected ICollection<IAnimal> ProcedureHistory { get; set; }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
