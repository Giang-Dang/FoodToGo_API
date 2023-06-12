using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DbEntities
{
    public class Shipper
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumberPlate { get; set; }
        public double Rating { get; set; }
    }
}
