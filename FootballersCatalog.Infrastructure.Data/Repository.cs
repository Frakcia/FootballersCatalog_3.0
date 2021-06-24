using FootballersCatalog.Interfaces.RepositoryInterfaces;
using System;
using System.Linq;

namespace FootballersCatalog.Infrastructure.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _applicationDbContext;
        public Repository(ApplicationContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _applicationDbContext.Set<TEntity>();
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            return _applicationDbContext.Set<TEntity>().Find(id);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            this._applicationDbContext.Set<TEntity>().Add(entity);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
