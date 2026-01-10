using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Wall : GameObject
    {
        public Wall()
        {
            Init();
        }

        public void Init()
        {
            Symbol = '#';
        }
    }
}
