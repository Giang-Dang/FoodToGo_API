﻿using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Models.DTO.CreateDTO
{
    public class NormalOpenHoursCreateDTO
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public int DayOfWeek { get; set; }
        public int SessionNo { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
