

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class PromotionCreateDTO
    {
        public int Id { get; set; }
        public int DiscountCreatorMerchanId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
