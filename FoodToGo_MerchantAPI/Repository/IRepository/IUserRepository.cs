using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<bool> IsUniqueUser(string username);
        Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO);
        Task<UserCreateDTO> Register(RegisterationRequestDTO registerationRequestDTO);
        Task<User> Update(User user);
    }
}
