

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class CustomerUpdateDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
    }
}
