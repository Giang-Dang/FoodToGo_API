using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Merchant")]
        public int DiscountCreatorMerchanId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Merchant Merchant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public int DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public int QuantityLeft { get; set; }
    }
}
