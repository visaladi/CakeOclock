using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class ResetPasswordDTO
    {
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }

        [Required]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
