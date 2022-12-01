using Microsoft.AspNetCore.Identity;

namespace PhoneShop.Domain
{
    /// <summary>
    /// Defines a user. Inherits from IdentityUser, so that
    /// Microsoft Identity knows this class can act as User
    /// </summary>
    public class AppUser : IdentityUser<Guid>
    {

    }
}