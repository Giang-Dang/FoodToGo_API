

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class OnlineCustomerLocationCreateDTO
    {
        public int CustomerId { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
    }
}
