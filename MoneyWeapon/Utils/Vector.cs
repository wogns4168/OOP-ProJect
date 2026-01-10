using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal struct Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            Y = y;
            X = x;
        }

        public static Vector Up => new Vector(0, -1);
        public static Vector Down => new Vector(0, 1);
        public static Vector Left => new Vector(-1, 0);
        public static Vector Right => new Vector(1, 0);

        public static Vector None => new Vector(0, 0);

        public static Vector operator +(Vector a, Vector b) 
            => new Vector(a.X + b.X, a.Y + b.Y);

        public static bool Near(Vector a, Vector b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) == 1;
        }
    }
}
