using System.Linq.Expressions;
using Yr25MagicVillaAPI.Models;

namespace Yr25MagicVillaAPI.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    { 
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
        


    }
}
