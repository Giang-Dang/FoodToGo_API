using FoodToGo_API.Models.Enums;
namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class OrderCreateDTO
    {
        public int Id { get; set; }
        public int MerchanId { get; set; }
        public int ShipperId { get; set; }
        public int CustomerId { get; set; }
        public int PromotionId { get; set; }
        public DateTime PlacedTime { get; set; }
        public DateTime ETA { get; set; }
        public DateTime DeliveryCompletionTime { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal AppFee { get; set; }
        public decimal PromotionDiscount { get; set; }
        public string Status { get; set; }
        public string? CancellationReason { get; set; }

    }
}
