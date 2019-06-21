using P08.MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }

        void CompleteMission(string codeName);
    }
}
