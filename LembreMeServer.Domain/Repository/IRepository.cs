using System.Collections.Generic;
using System.Threading.Tasks;

namespace LembreMeServer.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(long id, TEntity entity);
        Task RemoveAsync(long id);
    }
}
