using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
                
                   new VillaDTO { Id=1, Name="PoolView2", Occupancy=1,Sqft=20},
                   new VillaDTO { Id = 2, Name = "BeachView",Occupancy=2,Sqft=40 }
            };
    }


    
}
