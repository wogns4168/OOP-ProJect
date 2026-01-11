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
        public static bool IsActive { get; set; }


        public Player()
        {
            Init();
        }

        public void Init()
        {
            Symbol = 'P';
        }

        public Vector Update()
        {
            if (IsActive)
            {
                if (InputManager.GetKey(ConsoleKey.UpArrow))
                {
                    return Move(Vector.Up);
                }

                if (InputManager.GetKey(ConsoleKey.DownArrow))
                {
                    return Move(Vector.Down);
                }

                if (InputManager.GetKey(ConsoleKey.LeftArrow))
                {
                    return Move(Vector.Left);
                }

                if (InputManager.GetKey(ConsoleKey.RightArrow))
                {
                    return Move(Vector.Right);
                }
            }

            return Position;
            
        }

        public Vector Move(Vector direction)
        {
            Vector current = Position;
            Vector nextPos = NextPos(direction);


            GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

            if (nextTileObject != null) return current;

            Field[Position.Y, Position.X].OnTileObject = null;
            Field[nextPos.Y, nextPos.X].OnTileObject = this;
            Position = nextPos;

            return Position;
        }

        public Vector NextPos(Vector direction)
        {
            Vector Current = Position;
            Vector nextPos = Position + direction;
            return nextPos;

        }
        public void Render()
        {

        }
    }
}
