using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Interfaces
{
    public interface ISetDates
    {
        void SetCreateDate();
        void SetUpdateDate();
        void SetDeleteDate();
    }
}
