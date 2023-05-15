using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BanStartTime { get; set; }
        public TimeSpan BanLength { get; set; }
        public string BanReason { get; set; }
    }
}
