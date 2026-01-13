using MoneyWeapon.Scenes;
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

        public int AllBuyPrice { get; set; }

        public int PrevPrice { get; private set; }
        public float ChangeRate { get; private set; }

        private static Random rand = new Random();

        public Stock(string name, int price)
        {
            Name = name;
            Price = price * DungeonScene._curFloor;
            MinPrice = price / 10;
            MaxPrice = price * 10;
            MaxQuantity = 200;

            if(name == "폐지" || name == "노다지")
            {
                MinPrice = price;
                MaxPrice = price;
            }
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
