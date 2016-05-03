using FlatPlanet.Data.Helpers;
using FlatPlanet.Data.Interfaces;
using FlatPlanet.Infrastructure.ObjectStates;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : DomainBaseObject
    {
        protected readonly DbContext _context;
        public readonly IUnitOfWork UnitOfWork;

        public Repository(IUnitOfWork tUnitOfWork)
        {
            UnitOfWork = tUnitOfWork;

            _context = UnitOfWork.Context;
            _context.Set<T>();
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }



        public void InsertOrUpdate(T Entity)
        {
            if (Entity.objectState == ObjectState.Added)
            {
                // New entity
                Entity.SetCreateDate();
                Entity.SetUpdateDate();
                _context.Set<T>().Add(Entity);
            }
            else
            {
                // Existing entity 
                Entity.SetUpdateDate();
                _context.Entry(Entity).State = EntityState.Modified;
            }
        }

        public void RefreshContext(T Entity)
        {
            var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            objectContext.Refresh(RefreshMode.StoreWins, Entity);
        }

        public void ReplaceEntity(T OldEntity, T NewEntity)
        {
            _context.Entry(OldEntity).CurrentValues.SetValues(NewEntity);
        }

        public void InsertOrUpdateGraph(T Entity)
        {
            if (Entity.objectState == ObjectState.Added)
            {
                // New entity
                Entity.SetCreateDate();
                Entity.SetUpdateDate();
                _context.Entry(Entity).State = EntityState.Added;
            }
            else
            {
                // Existing entity
                Entity.SetUpdateDate();
                Entity.objectState = ObjectState.Modified;
                _context.Set<T>().Add(Entity);
                _context.ApplyObjectStateChanges();
                //set all parts of graph
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {//If we found the open house...
                entity.SetDeleteDate();
                entity.SetUpdateDate();
                _context.Set<T>().Remove(entity);
            }
        }

        public void Delete(int id1, int id2)
        {
            var entity = _context.Set<T>().Find(id1, id2);
            if (entity != null)
            {
                entity.SetUpdateDate();
                entity.SetDeleteDate();
                _context.Set<T>().Remove(entity);
            }
        }

        public void Clear() {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE Counter");
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().AsExpandable().Where(where);
        }

        public virtual IQueryable<T> GetMany()
        {
            return _context.Set<T>().AsExpandable();
        }

        public void Delete(IEnumerable<T> tRangeToRemove)
        {
            _context.Set<T>().RemoveRange(tRangeToRemove);
        }

        /// <summary>
        /// Get a single object of Type T from the repository. tAsReadOnly gives back an untracked object.
        ///     Primary use being getting old versions.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tAsReadOnly"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where, bool tAsReadOnly = false)
        {
            if (!tAsReadOnly)
            {
                return _context.Set<T>().FirstOrDefault(where);
            }

            return _context.Set<T>().AsNoTracking().FirstOrDefault(@where);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
