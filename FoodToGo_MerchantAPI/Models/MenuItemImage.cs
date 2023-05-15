using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models
{
    public class MenuItemImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public string Name { get; set; }
        public Byte[] ImageFile { get; set; }

    }
}
