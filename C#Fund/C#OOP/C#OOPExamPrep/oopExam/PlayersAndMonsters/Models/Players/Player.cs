﻿using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string userName, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = userName;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get => this.username;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.username = value;
            }           
        }

        public int Health
        {
            get => this.health;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            }
        }

        public bool IsDead
        {
            get => this.IsDead;
            private set
            {
                if(health < 0)
                {
                    IsDead = true;
                }
                else
                {
                    IsDead = false;
                }
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if(damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            this.Health -= damagePoints;
        }
    }
}
