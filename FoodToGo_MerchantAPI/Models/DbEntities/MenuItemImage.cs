using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class MenuItemImage
    {
        [Key]
        public int Id { get; set; }
        
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual MenuItem MenuItem { get; set; }
        public string Path { get; set; }

    }
}
