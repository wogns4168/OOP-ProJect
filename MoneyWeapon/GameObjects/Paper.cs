using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Paper : GameObject, Item
    {

        public string Name => "페지";
             
        public int Price => 5000;

        public int MinPrice => 5000;

        public int MaxPrice => 5000;

        public int MaxQuantity => 100;
        public Paper()
        {
            Symbol = '!';
        }


    }
}
