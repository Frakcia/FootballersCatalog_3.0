using System;
using System.Linq;

namespace FootballersCatalog.Interfaces.RepositoryInterfaces
{
    public interface IRepository : IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(object id) where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Save();
    }
}
