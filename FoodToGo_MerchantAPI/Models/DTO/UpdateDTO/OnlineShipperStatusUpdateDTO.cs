

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class OnlineShipperStatusUpdateDTO
    {
        public int ShipperId { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public bool IsAvailable { get; set; }
    }
}
