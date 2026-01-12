using MoneyWeapon.Utils;
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

        public int PrevPrice { get; private set; }
        public float ChangeRate { get; private set; }

        private static Random rand = new Random();

        public Stock(string name, int price, int minPrice, int maxPrice, int maxQuantity)
        {
            Name = name;
            Price = price;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MaxQuantity = maxQuantity;
        }

        public void RandomPrice()
        {
            PrevPrice = Price;
            Log.NomalLog("랜덤 실행");

            float rate = rand.Next(-30, 31) / 100f;

            int newPrice = (int)(Price * (1 + rate));

            if (newPrice < MinPrice) newPrice = MinPrice;
            if (newPrice > MaxPrice) newPrice = MaxPrice;
            Price = newPrice;

            ChangeRate = ((float)(Price - PrevPrice) / PrevPrice) * 100f;
        }
    }
}
