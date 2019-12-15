namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;

    public class Advanced : Player
    {
        private const int health = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, health)
        {
        }
    }
}
