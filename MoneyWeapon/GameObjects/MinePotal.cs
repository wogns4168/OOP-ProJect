using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class MinePotal : GameObject, IPotal
    {
        public string Name { get; } = "광산 입구";

        public MinePotal() => Symbol = '@';
    }
}
