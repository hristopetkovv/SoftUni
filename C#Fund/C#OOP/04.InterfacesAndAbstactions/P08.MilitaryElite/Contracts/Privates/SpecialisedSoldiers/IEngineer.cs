using System.Collections.Generic;
using P08.MilitaryElite.Models.Privates.SpecialisedSoldiers;

namespace P08.MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
