using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FoodToGo_API.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        [ForeignKey("MenuItemType")]
        public int ItemTypeId { get; set; }
        public virtual MenuItemType MenuItemType { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
