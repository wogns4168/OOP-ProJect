using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Managers
{
    internal static class InputManager
    {
        private static ConsoleKey _current;

        private static readonly ConsoleKey[] _keys =
        {
            ConsoleKey.UpArrow,
            ConsoleKey.DownArrow,
            ConsoleKey.LeftArrow,
            ConsoleKey.RightArrow,
            ConsoleKey.Enter,
            ConsoleKey.I,
            ConsoleKey.Spacebar,
            ConsoleKey.Escape,
            ConsoleKey.L,
        };

        public static bool GetKey(ConsoleKey input)
        {
            return _current == input;
        }

        public static void GetUserInput()
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            ResetKey();

            foreach (ConsoleKey key in _keys)
            {
                if (key == input)
                {
                    _current = input;
                    break;
                }
            }
        }

        public static void ResetKey()
        {
            _current = ConsoleKey.Clear;
        }
    }
}
