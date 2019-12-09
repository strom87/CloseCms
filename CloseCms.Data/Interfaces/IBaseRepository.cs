using System.Collections.Generic;
using System.Threading.Tasks;
using CloseCms.Data.Entities;

namespace CloseCms.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<TEntity> GetAsync(long id);
        Task<List<TEntity>> ListAsync(int skip = 0, int take = 1000);
        Task RemoveAsync(long id);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);
    }
}