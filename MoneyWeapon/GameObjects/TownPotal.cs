using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class TownPotal : GameObject, IPotal
    {
        public string Name { get; } = "마을 입구";

        public TownPotal() => Symbol = '@';

    }
}
