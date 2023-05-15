

namespace FoodToGo_API.Models.DTO
{
    public class OnlineCustomerLocationUpdateDTO
    {
        public int CustomerId { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongtitude { get; set; }
    }
}
