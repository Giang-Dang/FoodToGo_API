namespace FoodToGo_API.Models.DTO
{
    public class UserUpdateResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public UserDTO User { get; set; }
    }
}
