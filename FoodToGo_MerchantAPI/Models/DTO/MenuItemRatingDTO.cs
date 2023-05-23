﻿namespace FoodToGo_API.Models.DTO
{
    public class MenuItemRatingDTO
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}