using FlatPlanet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private FlatPlanetEntities _context;
        private DbContextTransaction mTransaction;

        public UnitOfWork()
        {
            _context = new FlatPlanetEntities();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public FlatPlanetEntities Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public void Reset()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            _context = new FlatPlanetEntities();
        }
        #region IUnitOfWork Members




        #endregion
    }
}
