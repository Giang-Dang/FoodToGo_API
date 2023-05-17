
namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class OrderDetailCreateDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string SpecialInstruction { get; set; }

    }
}
