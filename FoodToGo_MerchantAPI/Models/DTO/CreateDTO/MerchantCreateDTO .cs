﻿

using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class MerchantCreateDTO
    {
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public bool IsDeleted { get; set; } = false;
        public double Rating { get; set; } = 0;
    }
}
