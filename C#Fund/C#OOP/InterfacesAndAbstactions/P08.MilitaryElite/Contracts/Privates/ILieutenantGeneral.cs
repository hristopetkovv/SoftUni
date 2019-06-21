using P08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts.Privates
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
