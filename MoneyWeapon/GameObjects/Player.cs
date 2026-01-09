using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Player : GameObject
    {
        public Tile[,] Field { get; set; }

        public Player() 
        {
            Init();
        }

        public void Init()
        {
            Symbol = 'P';
        }

        public void Update()
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                Move(Vector.Up);
            }

            if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
                Move(Vector.Down);
            }

            if (InputManager.GetKey(ConsoleKey.LeftArrow))
            {
                Move(Vector.Left);
            }

            if (InputManager.GetKey(ConsoleKey.RightArrow))
            {
                Move(Vector.Right);
            }
        }

        public void Move(Vector direction)
        {
            Vector Current = Position;
            Vector nextPos = Position + direction;

            GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

            if (nextTileObject != null) return;

            Field[Position.Y, Position.X].OnTileObject = null;
            Field[nextPos.Y, nextPos.X].OnTileObject = this;
            Position = nextPos;
        }
    }
}
