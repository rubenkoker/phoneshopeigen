using System.ComponentModel.DataAnnotations;

namespace Phoneshop.Domain.Models
{
    public class LoginInputModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}