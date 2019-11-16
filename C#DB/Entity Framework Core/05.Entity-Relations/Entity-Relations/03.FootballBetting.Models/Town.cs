﻿namespace _03.FootballBetting.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
