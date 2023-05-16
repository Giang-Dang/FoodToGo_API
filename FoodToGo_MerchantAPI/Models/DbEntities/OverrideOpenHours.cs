using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodToGo_API.Models.DbEntities
{
    public class OverrideOpenHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public DateTime OverrideStartDate { get; set; }
        public DateTime OverrideEndDate { get; set; }
        public int DayOfWeek { get; set; }
        public int SessionNo { get; set; }
        public DateTime AltOpenTime { get; set; }
        public DateTime AltCloseTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
