﻿using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class UserCreateDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
