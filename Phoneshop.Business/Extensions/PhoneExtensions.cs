using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Extensions;

public static class PhoneExtensions
{
    public static decimal VATFreePrice(this Phone phone)
    {
        return phone.Price / 1.21m;
    }

    public static bool IsValid(this Phone phone, out string message)
    {
        if (phone == null)
        {
            message = "no telephone";
            return false;
        }
        if (phone.Brand == null)
        {
            message = "no brand";
            return false;
        }
        if (String.IsNullOrEmpty(phone.Type))
        {
            message = "no type";
            return false;
        }
        if (String.IsNullOrEmpty(phone.Brand.Name))
        {
            message = "brand needs a name";
            return false;
        }
        if (String.IsNullOrEmpty(phone.Description))
        {
            message = "needs a description";
            return false;
        }
        else
        {
            message = "phone is allright";
            return true;
        }
    }
}