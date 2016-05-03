using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T Entity);
        void InsertOrUpdateGraph(T Entity);
        void Delete(int id);
        void Delete(int id1, int id2);
        void Clear();
        int Save();
        T Get(Expression<Func<T, bool>> where, bool tAsReadOnly = false);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> GetMany();
        void ReplaceEntity(T OldEntity, T NewEntity);
        void RefreshContext(T Entity);
        void Delete(IEnumerable<T> tRangeToRemove);
    }
}
