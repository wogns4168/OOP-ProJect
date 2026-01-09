using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWeapon.GameObjects;

namespace MoneyWeapon.Utils
{
    internal struct Tile
    {
        public GameObject OnTileObject { get; set; }
        public Vector Position { get; set; }

        public bool HasGameObject => OnTileObject != null;

        public Tile (Vector position)
        {
            Position = position;
            OnTileObject = null;
        }

        public void Print()
        {
            if(HasGameObject)
            {
                OnTileObject.Symbol.Print();
            }
            else
            {
                ' '.Print();
            }
        }
    }
}
