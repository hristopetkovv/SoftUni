using P08.MilitaryElite.Contracts.Privates;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Models.Privates
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IReadOnlyCollection<Private> Privates { get; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                stringBuilder.AppendLine("  " + @private.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
