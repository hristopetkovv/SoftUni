namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        private const int defaultHealthPointsForBeginner = 40;
        private const int defaultDamagePointsForBeginner = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            CheckForBegginers(attackPlayer, enemyPlayer);
                
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (true)
            {
                var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private static void CheckForBegginers(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += defaultHealthPointsForBeginner;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += defaultDamagePointsForBeginner;
                }
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += defaultHealthPointsForBeginner;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += defaultDamagePointsForBeginner;
                }
            }
        }
    }
}
