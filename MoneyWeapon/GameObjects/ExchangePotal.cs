using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class ExchangePotal : GameObject, IPotal
    {
        public string Name { get; } = "주식 거래소";

        public Tile[,] Field { get; set; }

        public ExchangePotal() => Init();


        public void Init()
        {
            Symbol = '@';
        }

        public void Render(Vector position)
        {
            
        }
    }
}
