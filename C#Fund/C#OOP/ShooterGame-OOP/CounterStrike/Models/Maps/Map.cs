using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(t => t.GetType() == typeof(Terrorist))
                .ToList();

            var counterTerrorists = players
                .Where(ct => ct.GetType() == typeof(CounterTerrorist))
                .ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terro in terrorists.Where(t => t.IsAlive))
                {
                    if (!terro.IsAlive)
                    {
                        continue;
                    }

                    foreach (var counterTerro in counterTerrorists.Where(ct => ct.IsAlive))
                    {
                        if (!counterTerro.IsAlive)
                        {
                            continue;
                        }

                        counterTerro.TakeDamage(terro.Gun.Fire());
                    }
                }

                foreach (var counterTerro in counterTerrorists.Where(ct => ct.IsAlive))
                {
                    if (!counterTerro.IsAlive)
                    {
                        continue;
                    }

                    foreach (var terro in terrorists.Where(t => t.IsAlive))
                    {
                        if (!terro.IsAlive)
                        {
                            continue;
                        }

                        terro.TakeDamage(counterTerro.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;

            if (terrorists.Any(t => t.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else
            {
                result = "Counter Terrorist wins!";
            }

            return result;
        }
    }
}
