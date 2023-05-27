
namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class MenuItemCreateDTO
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int ItemTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsClosed { get; set; } = false;
    }
}
