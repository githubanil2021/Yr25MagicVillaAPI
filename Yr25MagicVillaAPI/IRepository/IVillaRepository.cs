using System.Linq.Expressions;
using Yr25MagicVillaAPI.Models;

namespace Yr25MagicVillaAPI.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    { 
        Task<Villa> UpdateAsync(Villa entity);
        


    }
}
