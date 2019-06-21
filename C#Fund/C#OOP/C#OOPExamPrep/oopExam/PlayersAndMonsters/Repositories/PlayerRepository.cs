using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        
        public int Count
        {
            get => Players.Count;       
        }

        public ICollection<IPlayer> Players
        {
            get;        
        }

        public void Add(IPlayer player)
        {
            if(player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }           

            if(Players.Contains(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            //foreach (var name in this.Players.Select(n => n.Username ==player.Username))
            //{
            //    throw new ArgumentException($"Player {player.Username} already exists!");
            //}

            Players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(c => c.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return Players.Remove(player);          
        }
    }
}
