

namespace FoodToGo_API.Models.DTO
{
    public class MenuItemImageCreateDTO
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public byte[] ImageFile { get; set; }

    }
}
