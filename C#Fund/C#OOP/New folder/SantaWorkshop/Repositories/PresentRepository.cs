﻿namespace SantaWorkshop.Repositories
{
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models =>
            (IReadOnlyCollection<IPresent>)this.models;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }
    }
}
