using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        public int Count
        {
            get => Cards.Count;
        }

        public ICollection<ICard> Cards { get; }
        

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if(Cards.Contains(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            Cards.Add(card);
        }

        public ICard Find(string name)
        {

            return this.Cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if(card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return Cards.Remove(card);
        }
    }
}
