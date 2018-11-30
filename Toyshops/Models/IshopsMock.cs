using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toyshops.Models
{
    public interface IshopsMock
    {
        IQueryable<shop> shops { get; }
        shop Save(shop shop);
        void Delete(shop shop);
    }
}
