using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _villaUrl;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration conf)
            :base(clientFactory) 
        {
            _clientFactory = clientFactory; 
            _villaUrl = conf.GetValue<string>("ServiceUrls:VillaAPI");
            
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = _villaUrl + "/api/villaNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                
                Url = _villaUrl + "/api/villaNumberAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                
                Url = _villaUrl + "/api/VillaNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                
                Url = _villaUrl + "/api/villaNumberAPI/"+id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = _villaUrl + "/api/villaNumberAPI/"+dto.VillaNo
            });

        }
    }
}
