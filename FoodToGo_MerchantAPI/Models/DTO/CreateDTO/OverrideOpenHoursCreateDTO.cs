using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class OverrideOpenHoursCreateDTO
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public DateTime OverrideStartDate { get; set; }
        public DateTime OverrideEndDate { get; set; }
        public int DayOfWeek { get; set; }
        public int SessionNo { get; set; }
        public DateTime AltOpenTime { get; set; }
        public DateTime AltCloseTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
