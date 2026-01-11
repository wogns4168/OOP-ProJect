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

        private static List<Stock> exchangeStockList = new List<Stock>();

        public ExchangeScene() => Init();

        public void Init()
        {
            exchangeStockList.Add(new Stock("주식 1", 10000, 1000, 100000, 100));
        }

        public override void Enter()
        {
            exchangeIsActive = true;
            Inventory.IsActive = true;
            Inventory.Onselect += SellItem;
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
            int start = Math.Max(0, exchangeStockList.Count - contentHeight);

            _outline.X = x + 10;
            _outline.Y = y;
            _outline.Width = 40;
            _outline.Height = 4 + exchangeStockList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 11, y + 1);
            "[거래소]".Print(ConsoleColor.Red);
            Console.SetCursorPosition(x + 25, y + 1);
            $"보유 금액 : {Player.Money}".Print(ConsoleColor.Green);
            Console.SetCursorPosition(x + 13, y + 2);
            "[이름]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 34, y + 2);
            "[가격]".Print(ConsoleColor.Yellow);



            for (int i = start; i < exchangeStockList.Count; i++)
            {
                var item = exchangeStockList[i];

                int X = _outline.X + 2;
                int Y = _outline.Y + 3 + (i - start);

                Console.SetCursorPosition(X, Y);

                if (i == CurrentIndex)
                {
                    "->".Print(ConsoleColor.Green);
                    item.Name.Print(ConsoleColor.Green);
                    Console.SetCursorPosition(X + 23, Y);
                    Console.WriteLine(item.Price);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    item.Name.Print();
                    Console.SetCursorPosition(X + 23, Y);
                    Console.WriteLine(item.Price);
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

        public void SellItem(int index)
        {

        }

        public void BuyItem(int index)
        {

        }
    }
}
