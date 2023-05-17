using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string SpecialInstruction { get; set; }

    }
}
