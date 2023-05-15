

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
        public double GeoLongtitude { get; set; }
        public DateTime OpenHour_1 { get; set; }
        public DateTime CloseHour_1 { get; set; }
        public DateTime? OpenHour_2 { get; set; }
        public DateTime? CloseHour_2 { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BanStartTime { get; set; }
        public TimeSpan BanLength { get; set; }
        public string BanReason { get; set; }
    }
}
