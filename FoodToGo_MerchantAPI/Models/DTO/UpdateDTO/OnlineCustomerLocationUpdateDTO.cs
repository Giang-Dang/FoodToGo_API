

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class OnlineCustomerLocationUpdateDTO
    {
        public int CustomerId { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
    }
}
