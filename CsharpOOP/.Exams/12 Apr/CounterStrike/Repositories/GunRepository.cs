using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => 
            (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IGun model)
        {
            if (this.models.Any(x => x.Name == model.Name))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }

        public IGun FindByName(string name)
        {
            IGun gun = this.models.FirstOrDefault(x => x.Name == name);
            return gun;
        }
        
    }
}