using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class Merchant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MerchantId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongtitude { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BanStartTime { get; set; }
        public TimeSpan BanLength { get; set; }
        public string BanReason { get; set; }
        public List<NormalOpenHours> NormalOpenHoursList { get; set; }
        public List<OverrideOpenHours> OverrideOpenHoursList { get; set; }
    }
}
