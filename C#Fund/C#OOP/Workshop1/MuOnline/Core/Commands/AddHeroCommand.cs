﻿using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AddHeroCommand : ICommand
    {
        private const string successfullMessage = "Successfully created hero: {0}";

        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory factory;

        public AddHeroCommand(IRepository<IHero> heroRepository, IHeroFactory factory)
        {
            this.heroRepository = heroRepository;
            this.factory = factory;
        }
        
        public string Execute(string[] inputArgs)
        {
            string heroType = inputArgs[0];
            string username = inputArgs[1];

            var hero = this.factory.Create(heroType, username);

            this.heroRepository.Add(hero);

            return string.Format(successfullMessage, username);
        }
    }
}
