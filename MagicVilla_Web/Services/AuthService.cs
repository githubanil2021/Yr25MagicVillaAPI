using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _villaUrl;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration conf)
            : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _villaUrl = conf.GetValue<string>("ServiceUrls:VillaAPI");

        }
    
        public Task<T> LoginAsync<T>(LoginRequestDTO objToCreate)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = objToCreate,
                Url = _villaUrl + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO objToReg)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = objToReg,
                Url = _villaUrl + "/api/UsersAuth/register"
            });
        }
    }
}
