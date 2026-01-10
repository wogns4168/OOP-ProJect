using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class DungeonPotal : GameObject, IPotal
    {
        public string Name { get; } = "던전 입구";

        public DungeonPotal() => Symbol = '@';

    }
}
