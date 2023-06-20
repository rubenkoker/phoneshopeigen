using Microsoft.AspNetCore.Identity;

namespace PhoneShop.Domain
{
    /// <summary>
    /// Defines a role a user can have. Inherits from IdentityRole, so that
    /// Microsoft Identity knows this class can act as Role
    /// </summary>
    public class AppUserRole : IdentityRole<Guid>
    {
    }
}