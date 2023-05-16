using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class UserUpdateInfoDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
