namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;

        public ManagerController()
        {
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            PlayerRepository playerRepository = new PlayerRepository();

            var player = playerRepository.Players.FirstOrDefault(p => p.Username == username);

            ICard card = this.cardFactory.CreateCard(null, cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            BattleField battlefield = new BattleField();

            PlayerRepository playerRepository = new PlayerRepository();

            IPlayer attackPlayer = playerRepository.Players.FirstOrDefault(p => p.Username == attackUser);

            IPlayer enemyPlayer = playerRepository.Players.FirstOrDefault(p => p.Username == enemyUser);

            battlefield.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo,attackPlayer.Health,enemyPlayer.Health);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
