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
        public string Name { get; } = "거래소 입구";


        public ExchangePotal() => Symbol = '@';

    }
}
