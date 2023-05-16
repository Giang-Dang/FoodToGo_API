namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class BanUpdateDTO
    {
        public int BanId { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
