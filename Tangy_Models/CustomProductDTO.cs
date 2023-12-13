using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class CustomProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
       
        public string ImageUrl { get; set; }

        public DateTime RequiredDate { get; set; }
    }
}
