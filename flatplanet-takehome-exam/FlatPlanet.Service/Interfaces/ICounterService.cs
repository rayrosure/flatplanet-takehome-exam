using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Service.Interfaces
{
    public interface ICounterService
    {
        int GetLatestCount();
        int IncreaseCount();
        void ResetCount();
    }
}
