

using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class MerchantUpdateDTO
    {
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongtitude { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BanStartTime { get; set; }
        public TimeSpan BanLength { get; set; }
        public string BanReason { get; set; }
        public List<NormalOpenHoursUpdateDTO> NormalOpenHoursList { get; set; }
        public List<OverrideOpenHoursUpdateDTO> OverrideOpenHoursList { get; set; }
    }
}
