using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LembreMeServer.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected IAppContext _appContext;

        public Repository(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Add(TEntity entity)
        {
            _appContext.Set<TEntity>().Add(entity);
            _appContext.SaveChanges();
        }

        public TEntity Get(long id)
        {
            return _appContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _appContext.Set<TEntity>().ToList();
        }

        public void Update(long id, TEntity entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            _appContext.SaveChanges();
        }

        public void Remove(long id)
        {
            TEntity toRemove = _appContext.Set<TEntity>().Find(id);
            _appContext.Set<TEntity>().Remove(toRemove);
            _appContext.SaveChanges();
        }
    }
}
