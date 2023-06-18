using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using System.Linq.Expressions;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>>? filter, int pageSize, int pageNumber);
        Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true);
        Task<bool> IsUniqueUser(string username);
        Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO);
        Task<User> UpdateAsync(User user);
    }
}
