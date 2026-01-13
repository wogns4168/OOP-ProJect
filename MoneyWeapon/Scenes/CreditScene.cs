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
            "[크레딧]".Print();

            Console.SetCursorPosition(95, 1);
            "뒤로가기 버튼 : ESC".Print();
            Console.SetCursorPosition(45, 5);
            "[김재성] 강사님!".Print();
            Console.SetCursorPosition(45, 7);
            "[최영민] 강사님!".Print();
            Console.SetCursorPosition(45, 9);
            "[이태호] 매니저님!".Print();
            Console.SetCursorPosition(45, 11);
            "[진유록] 매니저님!".Print();
            Console.SetCursorPosition(45, 13);
            "[경일] 수강생 분들 모두!".Print();
            int startX = 27;
            int startY = 17;

            for (int i = 0; i < CreditImage.creditMentLines.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                $"{CreditImage.creditMentLines[i]}".Print(ConsoleColor.Red);
            }
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
