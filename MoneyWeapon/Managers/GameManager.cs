using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Managers
{
    internal class GameManager
    {
        public const string GameName = "무기 : 통장";
        public const string SubGameTitle = "마왕 잡기 전에 손절부터";
        public static bool IsGameOver {  get; set; }

        public void Run()
        {
            while(!IsGameOver)
            {
                Console.Clear();
            }

        }

        public void Init()
        {

        }
    }
}
