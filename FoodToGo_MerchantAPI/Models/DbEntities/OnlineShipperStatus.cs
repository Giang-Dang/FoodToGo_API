using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class OnlineShipperStatus
    {
        [Key]
        [ForeignKey("Shipper")]
        public int ShipperId { get; set; }
        public virtual Shipper Shipper { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public bool IsAvailable { get; set; }
    }
}
