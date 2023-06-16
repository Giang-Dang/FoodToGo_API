using FoodToGo_API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Merchant Merchant { get; set; }
        public int? ShipperId { get; set; }
        [ForeignKey("ShipperId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Shipper? Shipper { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Customer Customer { get; set; }
        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public virtual Promotion? Promotion { get; set; }
        public DateTime PlacedTime { get; set; }
        public DateTime ETA { get; set; }
        public DateTime? DeliveryCompletionTime { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal AppFee { get; set; }
        public decimal PromotionDiscount { get; set; }
        public string Status { get; set; }
        public string? cancelledBy { get; set; }
        public string? CancellationReason { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public string DeliveryAddress { get; set; }
        public double DeliveryLongitude { get; set; }
        public double DeliveryLatitude { get; set; }


    }
}
