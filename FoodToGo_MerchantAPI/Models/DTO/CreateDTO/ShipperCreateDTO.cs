
namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class ShipperCreateDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumberPlate { get; set; }
        public double Rating { get; set; } = 0;
    }
}
