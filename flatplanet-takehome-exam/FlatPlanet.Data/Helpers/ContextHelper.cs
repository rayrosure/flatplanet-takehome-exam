using FlatPlanet.Infrastructure.ObjectStates;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Helpers
{
    public static class ContextHelper
    {
        public static void ApplyObjectStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = ObjectStateHelper.ConvertState(stateInfo.objectState);
            }
        }

    }
}
