using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoneyWeapon.GameObjects
{
    internal interface IPotal
    {
        string Name { get; }

        void Render(Vector position);
    }
}
