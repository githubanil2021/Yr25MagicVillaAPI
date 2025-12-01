using Yr25MagicVillaAPI.Models;
using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
