using System.Collections.Generic;

namespace LembreMeServer.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        void Update(long id, TEntity entity);
        void Remove(long id);
    }
}
