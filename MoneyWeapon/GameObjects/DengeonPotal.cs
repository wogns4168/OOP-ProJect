using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class DengeonPotal : GameObject, IPotal
    {
        public string Name { get; } = "던전";

        public DengeonPotal() => Init();


        public void Init()
        {
            Symbol = '@';
        }

        public void Render(Vector position)
        {

        }
    }
}
