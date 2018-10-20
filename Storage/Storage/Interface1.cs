using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int ShelfLife { get; set; }
    }
}
