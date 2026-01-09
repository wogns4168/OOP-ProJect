using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal static class Tutorial
    {
        public static void Render(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            "[기본 조작법]".Print();

            Console.SetCursorPosition(x, y + 1);
            "상 : UpArrow\t인벤토리 : I".Print();

            Console.SetCursorPosition(x, y + 2);
            "하 : DownArrow\t상호작용 : Enter".Print();

            Console.SetCursorPosition(x, y + 3);
            "좌 : LeftArrow\t공격 : Space".Print();

            Console.SetCursorPosition(x, y + 4);
            "우 : RightArrow\t로그 : L".Print();
        }
    }
}
