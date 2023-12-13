using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class CustomOrderDetailDTO
    {
        public int Id { get; set; }

        [Required]
        public int CustomOrderHeaderId { get; set; }

        [Required]
        public int CustomProductId { get; set; }        

        public CustomProductDTO CustomProduct { get; set; }

        [Required]
        public int Count { get; set;}

        [Required]
        public double Price { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string CustomProductName { get; set; }
    }
}
