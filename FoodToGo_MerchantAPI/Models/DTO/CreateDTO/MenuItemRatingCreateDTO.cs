namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class MenuItemRatingCreateDTO
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }
        public double Rating { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
