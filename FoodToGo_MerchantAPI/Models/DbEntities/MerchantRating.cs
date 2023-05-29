using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodToGo_API.Models.DbEntities
{
    public class MerchantRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User FromUser { get; set; }
        public string FromUserType { get; set; }
        public int ToMerchantId { get; set; }
        [ForeignKey("ToMerchantId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Merchant ToMerchant { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Order Order { get; set; }
        public double Rating { get; set; }
    }
}
