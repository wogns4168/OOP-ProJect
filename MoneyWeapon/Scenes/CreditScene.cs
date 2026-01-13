using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class CreditScene : Scene
    {

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Render()
        {
            Console.SetCursorPosition(2, 1);
            "크레딧".Print(ConsoleColor.DarkBlue);
            Console.SetCursorPosition(1, 8);
            "~~~ 강사님".Print(ConsoleColor.Blue);
            "뒤로가기 버튼 : ESC".Print();
        }

        public override void Update()
        {
            if(InputManager.GetKey(ConsoleKey.Escape))
            {
                SceneManager.ChangePrevScene();
            }
        }
    }
}
