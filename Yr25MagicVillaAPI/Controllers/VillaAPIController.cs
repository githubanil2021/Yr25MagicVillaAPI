using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yr25MagicVillaAPI.Data;
using Yr25MagicVillaAPI.Models;
using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
         
        //public IEnumerable<Villa> GetVillas()
        //{
        //    return new List<Villa> {
        //          new Villa { Id=1, Name="PoolView"},
        //           new Villa { Id = 2, Name = "BeachView" }
        //    };

        //}
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.villaList;

        }

        [HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u=>u.Id==id);

        }
    }
}
