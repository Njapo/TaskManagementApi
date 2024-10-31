using TaskManagementApi.Models;
using TaskManagementApi.Models.DTO;

namespace TaskManagementApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Rgeister(RegistrationRequestDTO registrationRequestDTO);
    }
}
