using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DbEntities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
        [AllowNull]
        public DateTime BanStartTime { get; set; }
        [AllowNull]
        public TimeSpan BanLength { get; set; }
        [AllowNull]
        public string BanReason { get; set; }
    }
}
