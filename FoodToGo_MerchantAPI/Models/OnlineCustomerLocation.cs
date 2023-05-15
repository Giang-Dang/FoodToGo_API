﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodToGo_API.Models
{
    public class OnlineCustomerLocation
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongtitude { get; set; }
    }
}
