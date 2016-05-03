using FlatPlanet.Data.Interfaces;
using FlatPlanet.Infrastructure.ObjectStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data
{
    public abstract class DomainBaseObject : IObjectWithState, ISetDates
    {
        public DomainBaseObject()
        {
            objectState = ObjectState.Unchanged;
            Init();
        }

        #region IObjectWithState Members

        public ObjectState objectState { get; set; }



        #endregion

        public virtual void SetCreateDate()
        {

        }

        public virtual void SetUpdateDate()
        {
        }

        public virtual void SetDeleteDate()
        {
        }

        public virtual void Init()
        {
        }
    }
}
