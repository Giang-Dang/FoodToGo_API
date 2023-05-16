using FoodToGo_API.Models.DbEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models.DTO
{
    public class BanDTO
    {
        public int BanId { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
