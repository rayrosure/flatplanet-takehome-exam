using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Interfaces
{
    public interface IUnitOfWork
    {
        //void Commit();
        FlatPlanetEntities Context { get; set; }
        void Reset();
    }
}
