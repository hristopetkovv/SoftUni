using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            int index = gladiators.FindIndex(g => g.Name == name);

            if(index != -1)
            {
                this.gladiators.RemoveAt(index);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(g => g.GetStatPower()).First();

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(g => g.GetWeaponPower()).First();

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(g => g.GetTotalPower()).First();

            return gladiator;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Count} gladiators are participating.";
        }
    }
}
