using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface ICaching<TItem>
    {
        TItem GetOrCreate(object key, Func<TItem> createItem);
    }
}
