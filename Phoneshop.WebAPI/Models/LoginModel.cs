using System.ComponentModel.DataAnnotations;

namespace PhoneShop.API.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}