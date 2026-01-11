using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal interface Item
    {
        string Name { get; }
        int Price { get; }

        int MinPrice { get; }
        int MaxPrice { get; }

        int MaxQuantity { get; }
    }
}
