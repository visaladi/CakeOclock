using System.ComponentModel.DataAnnotations;
using Tangy_Models;

namespace TangyWeb_Client.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM() 
        {
            ProductPrice = new();
            Count = 1;
        }

        [Range(1, int.MaxValue, ErrorMessage ="Please Enter a value greater than 0")]
        public int Count { get; set; }

        [Required]
        public int SelectedProductPriceId { get; set; }
        public ProductPriceDTO ProductPrice { get; set; } // can get price and size from this model

    }
}
