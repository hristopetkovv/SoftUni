using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon )
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()  
        {
            int weaponPower = this.GetWeaponPower();
            int statPower = this.GetStatPower();

            int totalPower = weaponPower + statPower;

            return totalPower;
        }

        public int GetWeaponPower()
        {
            int sharpness = this.Weapon.Sharpness;
            int size = this.Weapon.Size;
            int solidity = this.Weapon.Solidity;

            int sumOfWeaponPower = sharpness + size + solidity;

            return sumOfWeaponPower;
        }

        public int GetStatPower()
        {
            int strength = this.Stat.Strength;
            int flexibility = this.Stat.Flexibility;
            int agility = this.Stat.Agility;
            int skills = this.Stat.Skills;
            int intelligence = this.Stat.Intelligence;

            int sumOfStatPower = strength + flexibility + agility + skills + intelligence;

            return sumOfStatPower;             
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {this.GetStatPower()}");

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
