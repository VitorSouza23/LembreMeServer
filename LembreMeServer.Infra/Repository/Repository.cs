using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LembreMeServer.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected IAppContext _appContext;

        public Repository(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            _appContext.Set<TEntity>().Add(entity);
            await _appContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await _appContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appContext.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(long id, TEntity entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            TEntity toRemove =  await _appContext.Set<TEntity>().FindAsync(id);
            _appContext.Set<TEntity>().Remove(toRemove);
            await _appContext.SaveChangesAsync();
        }
    }
}
