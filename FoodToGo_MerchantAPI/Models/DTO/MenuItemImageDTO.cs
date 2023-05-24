

namespace FoodToGo_API.Models.DTO
{
    public class MenuItemImageDTO
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string FileName { get; set; }
        public byte[] ImageFile { get; set; }

    }
}
