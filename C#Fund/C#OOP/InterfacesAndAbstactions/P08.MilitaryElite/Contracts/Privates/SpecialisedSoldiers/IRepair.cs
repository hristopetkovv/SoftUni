﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
