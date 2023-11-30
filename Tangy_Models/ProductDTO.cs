using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool ShopFavourites { get; set; }
        public bool CustomerFavourites { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
       
        public CategoryDTO Category { get; set; }
        public ICollection<ProductPriceDTO> ProductPrices { get; set; }
    }
}
