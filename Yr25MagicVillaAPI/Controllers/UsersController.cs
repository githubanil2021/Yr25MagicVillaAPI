using Microsoft.AspNetCore.Mvc;
using System.Net;
using Yr25MagicVillaAPI.IRepository;
using Yr25MagicVillaAPI.Models;
using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private APIResponse _apiResponse;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._apiResponse = new();
        }

        [HttpPost("login")]
        public async  Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if(loginResponse.User==null || string.IsNullOrEmpty( loginResponse.Token))
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess=false;
                _apiResponse.ErrorMessages.Add("Username/Pass is incorrect");

                return BadRequest(_apiResponse);
            }


            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result= loginResponse;

            return View(_apiResponse);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool ifUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUnique)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Username already");

                return BadRequest(_apiResponse);
            }

            var user = await _userRepo.Register(model);
            if(user ==null)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Error in Register");

                return BadRequest(_apiResponse);
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;

            return Ok(_apiResponse);
        }
    }
}
