using FoodToGo_API.Models.Enums;
namespace FoodToGo_API.Models.DTO
{
    public class OrderDTO
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
        public OrderStatus Status { get; set; }
        public float ShipperRating { get; set; }
        public float CustomerRating { get; set; }
        public float MerchantRating { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }

    }
}
