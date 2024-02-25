using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class ForgotPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
