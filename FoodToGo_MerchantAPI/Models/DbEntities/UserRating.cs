using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class UserRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User FromUser { get; set; }
        public string FromUserType { get; set; }
        public int ToUserId { get; set; }
        [ForeignKey("ToUserId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User ToUser { get; set; }
        public string ToUserType { get; set; }
        public double Rating { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Order Order { get; set; }
    }
}
