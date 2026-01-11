using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class ExchangeScene : Scene
    {
        public static bool exchangeIsActive { get; set; }
        private static Ractangle _outline;
        const int MaxHeight = 15;

        private static int CurrentIndex { get; set; }

        private static List<(string text, Action action)> exchangeList = new List<(string, Action)>();

        public ExchangeScene() => Init();

        public void Init()
        {
        }

        public override void Enter()
        {
            exchangeIsActive = true;
            Inventory.IsActive = true;
        }

        public override void Exit()
        {
            exchangeIsActive = false;
            Inventory.IsActive = false;
        }

        public override void Render()
        {
            Tutorial.Render(5, 1);
            RenderShop(0, 10);
        }

        public static void RenderShop(int x, int y)
        {
            if (!exchangeIsActive) return;

            int contentHeight = MaxHeight - 3;
            int start = Math.Max(0, exchangeList.Count - contentHeight);

            _outline.X = x + 10;
            _outline.Y = y;
            _outline.Width = 40;
            _outline.Height = 3 + exchangeList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 11, y + 1);
            "[거래소]".Print(ConsoleColor.Red);



            for (int i = start; i < exchangeList.Count; i++)
            {
                var (text, action) = exchangeList[i];

                Console.SetCursorPosition(x + 12, y + 2 + (i - start));

                if (i == CurrentIndex)
                {
                    "->".Print(ConsoleColor.Green);
                    text.Print(ConsoleColor.Green);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    text.Print();
                }
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
