using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal abstract class GameObject
    {
        public Tile[,] Field {  get; set; }
        public char Symbol { get; set; }
        
        public Vector Position { get; set; }
    }
}
