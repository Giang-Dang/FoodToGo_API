using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class MenuItemRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public MenuItem MenuItem { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Customer Customer { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
