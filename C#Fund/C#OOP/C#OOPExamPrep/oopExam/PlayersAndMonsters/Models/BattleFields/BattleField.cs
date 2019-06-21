using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if(attackPlayer.IsDead==true)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }

            if(attackPlayer is Beginner beginner)
            {
                attackPlayer.Health += 40;
                CardRepository card = new CardRepository();                
            }

            if(enemyPlayer is Beginner beginner2)
            {
                enemyPlayer.Health += 40;      
            }
        
        }
    }
}
