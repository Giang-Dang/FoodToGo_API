﻿

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class MenuItemImageCreateDTO
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string FileName { get; set; }
        public byte[] ImageFile { get; set; }

    }
}
