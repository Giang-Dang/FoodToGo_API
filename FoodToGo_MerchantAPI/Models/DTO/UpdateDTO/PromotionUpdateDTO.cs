

namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class PromotionUpdateDTO
    {
        public int Id { get; set; }
        public int DiscountCreatorMerchantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public int QuantityLeft { get; set; }
    }
}
