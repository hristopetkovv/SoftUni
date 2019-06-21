namespace PlayersAndMonsters.Repositories.Contracts
{
    using System.Collections.Generic;

    using Models.Players.Contracts;

    public interface IPlayerRepository
    {
        int Count { get; }

        ICollection<IPlayer> Players { get; }

        void Add(IPlayer player);

        bool Remove(IPlayer player);

        IPlayer Find(string username);
    }
}
