﻿

namespace FoodToGo_API.Models.DTO
{
    public class OnlineShipperStatusCreateDTO
    {
        public int ShipperId { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public bool IsAvailable { get; set; }
    }
}
