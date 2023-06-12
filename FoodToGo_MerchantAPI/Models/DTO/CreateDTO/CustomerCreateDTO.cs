﻿

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class CustomerCreateDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; } = 0;
    }
}
