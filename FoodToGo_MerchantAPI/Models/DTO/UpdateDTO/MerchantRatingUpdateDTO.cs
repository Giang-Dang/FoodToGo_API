namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class MerchantRatingUpdateDTO
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public string FromUserType { get; set; }
        public int ToMerchantId { get; set; }
        public double Rating { get; set; }
    }
}
