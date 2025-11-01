using AutoMapper;
using Yr25MagicVillaAPI.Models;
using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();


            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
        }
    }
}
