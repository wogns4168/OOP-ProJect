using MoneyWeapon.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal class InventorySlot
    {
        public Stock stock { get; }
        public int Quantity { get; set; }

        public InventorySlot(Stock stock, int quantity)
        {
            this.stock = stock;
            this.Quantity = quantity;
        }
    }
}
