namespace Phoneshop.PhoneExtensions;
public class PhoneExtensions
{
    public decimal VATFreePrice(this Phone phone)
    {
        return Price / 1.21m;
    }

}
