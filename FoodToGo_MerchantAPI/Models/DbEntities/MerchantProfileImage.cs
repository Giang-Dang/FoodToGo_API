using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodToGo_API.Models.DbEntities
{
    public class MerchantProfileImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public string FileName { get; set; }
        public byte[] ImageFile { get; set; }

    }
}
