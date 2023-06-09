﻿namespace FoodToGo_API.Models.DTO
{
    public class UserRatingDTO
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public string FromUserType { get; set; }
        public int ToUserId { get; set; }
        public string ToUserType { get; set; }
        public int OrderId { get; set; }
        public double Rating { get; set; }
    }
}
