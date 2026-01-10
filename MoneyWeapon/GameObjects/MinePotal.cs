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
        public string Name { get; } = "광산";

        public Tile[,] Field { get; set; }

        public MinePotal() => Init();


        public void Init()
        {
            Symbol = '@';
        }

        public void Render(Vector position)
        {

        }
    }
}
