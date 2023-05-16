namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class BanCreateDTO
    {
        public int BanId { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
