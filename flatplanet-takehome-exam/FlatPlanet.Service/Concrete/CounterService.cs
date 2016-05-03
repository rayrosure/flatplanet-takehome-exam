using FlatPlanet.Data;
using FlatPlanet.Data.Interfaces;
using FlatPlanet.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Service.Concrete
{
    public class CounterService : ICounterService
    {
        public IRepository<Counter> _repository;

        public CounterService(IRepository<Counter> repository) {
            this._repository = repository;
        }

        public int GetLatestCount()
        {
            var result = this._repository.GetMany().Count();
            return result;
        }

        public int IncreaseCount() {
           int lastCount = this.GetLatestCount();
            this._repository.InsertOrUpdate(new Counter() { objectState = Infrastructure.ObjectStates.ObjectState.Added, Id = ++lastCount });
           this._repository.Save();

            return this.GetLatestCount();
        }

        public void ResetCount() {
            this._repository.Clear();
        }
    }
}
