using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tangy_DataAccess
{
    public class CustomOrderDetail
    {
        public int Id { get; set; }

        [Required]
        public int CustomOrderHeaderId { get; set; }

        [Required]
        public int CustomProductId { get; set; }
        [ForeignKey("CustomProductId")]

        [NotMapped]
        public virtual CustomProduct CustomProduct { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string CustomProductName { get; set; }
    }
}
