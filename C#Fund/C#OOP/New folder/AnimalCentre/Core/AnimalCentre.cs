namespace AnimalCentre.Core
{
    using global::AnimalCentre.Core.AnimalFactory;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Hotels;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;

    public class AnimalCentre
    {
        private IAnimalFactory animalFactory;
        private readonly IHotel hotel;
        private Dictionary<string, IProcedure> procedureAnimals;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory.AnimalFactory();
            this.hotel = new Hotel();

            this.procedureAnimals = new Dictionary<string, IProcedure>
            {
                {"Chip", new Chip() },
                {"DentalCare", new DentalCare() },
                {"Fitness", new Fitness() },
                {"Play", new Play() },
                {"NailTrim", new NailTrim() },
                {"Vaccinate", new Vaccinate() }
            };
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["Vaccinate"].DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["Fitness"].DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["Play"].DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["DentalCare"].DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];

            this.procedureAnimals["NailTrim"].DoService(animal, procedureTime);


            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            this.CheckAnimalExist(animalName);

            var animal = this.hotel.Animals[animalName];

            this.hotel.Adopt(animalName, owner);

            return animal.IsChipped
                ? $"{owner} adopted animal with chip"
                : $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            return this.procedureAnimals[type].History();
        }

        private void CheckAnimalExist(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }

    }
}
