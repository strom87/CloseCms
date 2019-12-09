using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CloseCms.Data.Context;
using CloseCms.Data.Entities;
using CloseCms.Data.Interfaces;

namespace CloseCms.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected CloseCmsContext Context;

        public BaseRepository(CloseCmsContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await Context.Set<TEntity>().FirstAsync(x => x.Id.Equals(id));
        }

        public async Task<List<TEntity>> ListAsync(int skip = 0, int take = 1000)
        {
            return await Context.Set<TEntity>().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var created = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return created.Entity;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updated = Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();

            return updated.Entity;
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(List<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            var entity = await Context.Set<TEntity>().FirstAsync(x => x.Id.Equals(id));
            if (entity == null) return;

            await RemoveAsync(entity);
        }
    }
}
