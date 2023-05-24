namespace FoodToGo_API.Models.DTO.UpdateDTO
{
    public class MerchantProfileImageUpdateDTO
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string FileName { get; set; }
        public byte[] ImageFile { get; set; }
    }
}
