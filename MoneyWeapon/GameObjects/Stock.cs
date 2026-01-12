using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Stock : Item
    {
        public string Name { get; }
        public int Price { get; private set; }

        public int MinPrice { get; }
        public int MaxPrice { get; }
        public int MaxQuantity { get; }

        public int AvgPrice { get; set; }


        public Stock(string name, int price, int minPrice, int maxPrice, int maxQuantity)
        {
            Name = name;
            Price = price;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MaxQuantity = maxQuantity;
        }
    }
}
