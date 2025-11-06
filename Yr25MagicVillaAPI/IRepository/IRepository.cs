using System.Linq.Expressions;
using Yr25MagicVillaAPI.Models;

namespace Yr25MagicVillaAPI.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties=null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);


        Task CreateAsync(T entity);
        //Task UpdateAsync(Villa entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();

    }
}
