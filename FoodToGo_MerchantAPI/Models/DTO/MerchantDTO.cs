

using FoodToGo_API.Models.DbEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DTO
{
    public class MerchantDTO
    {
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
    }
}
