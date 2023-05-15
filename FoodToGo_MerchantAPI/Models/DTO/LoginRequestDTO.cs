using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DTO
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string loginFromApp { get; set; }
    }
}
