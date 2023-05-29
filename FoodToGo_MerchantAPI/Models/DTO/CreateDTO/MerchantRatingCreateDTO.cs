namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class MerchantRatingCreateDTO
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public string FromUserType { get; set; }
        public int ToMerchantId { get; set; }
        public int OrderId { get; set; }
        public double Rating { get; set; }
    }
}
