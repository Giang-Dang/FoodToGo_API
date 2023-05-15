using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DTO
{
    public class RegisterationRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
