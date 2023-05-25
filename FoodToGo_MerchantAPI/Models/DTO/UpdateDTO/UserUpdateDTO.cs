using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
