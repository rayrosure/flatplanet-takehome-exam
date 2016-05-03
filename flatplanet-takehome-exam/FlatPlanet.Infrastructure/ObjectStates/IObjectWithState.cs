using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Infrastructure.ObjectStates
{
    public interface IObjectWithState
    {
        ObjectState objectState { get; set; }
    }
}
