namespace FoodToGo_API.Models.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO? User { get; set; }
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
