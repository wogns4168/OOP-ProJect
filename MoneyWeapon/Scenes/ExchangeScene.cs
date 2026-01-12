using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class ExchangeScene : Scene
    {
        public static bool exchangeIsActive { get; set; }
        private static Ractangle _outline;
        const int MaxHeight = 15;
        public static bool IsInventoryUse;
        private static bool IsExchangeUse;

        private static int CurrentIndex { get; set; }

        private static List<Stock> exchangeStockList = new List<Stock>();

        public ExchangeScene() => Init();

        public void Init()
        {
            exchangeStockList.Add(new Stock("주식 1", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 2", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 3", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 4", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 5", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 6", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 7", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 8", 10000, 1000, 100000, 100));
            exchangeStockList.Add(new Stock("주식 9", 10000, 1000, 100000, 100));

            Inventory.Add(new Stock("주식 1", 10000, 1000, 100000, 100), 80);
            Inventory.Add(new Stock("주식 2", 10000, 1000, 100000, 100), 3);
            Inventory.Add(new Stock("주식 3", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 4", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 5", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 6", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 7", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 8", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 9", 10000, 1000, 100000, 100), 5);
            Inventory.Add(new Stock("주식 10", 10000, 1000, 100000, 100), 5);
        }

        public override void Enter()
        {
            exchangeIsActive = true;
            Inventory.IsActive = true;
            IsExchangeUse = true;
            IsInventoryUse = false;
        }

        public override void Exit()
        {
            exchangeIsActive = false;
            Inventory.IsActive = false;
            IsInventoryUse = true;
            IsExchangeUse = false;
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

            _outline.X = x + 5;
            _outline.Y = y;
            _outline.Width = 50;
            _outline.Height = 4 + exchangeStockList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 6, y + 1);
            "[거래소]".Print(ConsoleColor.Red);
            Console.SetCursorPosition(x + 9, y + 2);
            "[이름]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 22, y + 2);
            "[가격]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 40, y + 2);
            "[등락률]".Print(ConsoleColor.Yellow);



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
                    Console.SetCursorPosition(X + 15, Y);
                    Console.WriteLine($"{item.Price} 원");
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    item.Name.Print();
                    Console.SetCursorPosition(X + 15, Y);
                    Console.WriteLine($"{item.Price} 원");
                }
            }

        }

        public override void Update()
        {
            if (InputManager.GetKey(ConsoleKey.Escape))
            {
                SceneManager.ChangePrevScene();
            }

            UIUpdate();
            if (IsExchangeUse == true)
            {
                if (InputManager.GetKey(ConsoleKey.RightArrow))
                {
                    PocusUI();
                }
            }
            else
            {
                if (InputManager.GetKey(ConsoleKey.LeftArrow))
                {
                    PocusUI();
                }
            }
        }

        public static void Sell(Stock stock, int number)
        {
            if (Inventory.GetQuantity(stock) < number) return;

            Player.Money += stock.Price * number;
            Inventory.Remove(stock, number);
        }

        public static void Buy(Stock stock, int number)
        {
            int price = stock.Price * number;

            if (Player.Money < price) return;
            if (stock.MaxQuantity < Inventory.GetQuantity(stock) + number) return;

            Player.Money -= price;
            Inventory.Add(stock, number);
        }

        public static void PocusUI()
        {
            IsExchangeUse = !IsExchangeUse;
            IsInventoryUse = !IsExchangeUse;
        }

        public static void UIUpdate()
        {
            if (IsExchangeUse == true)
            {
                if (InputManager.GetKey(ConsoleKey.UpArrow))
                {
                    SelectUp();
                }

                if (InputManager.GetKey(ConsoleKey.DownArrow))
                {
                    SelectDown();
                }

                if (InputManager.GetKey(ConsoleKey.Enter))
                {
                    Select();
                }
            }
        }

        public static void SelectUp()
        {
            CurrentIndex--;

            if (CurrentIndex < 0)
                CurrentIndex = 0;
        }

        public static void SelectDown()
        {
            CurrentIndex++;

            if (CurrentIndex >= exchangeStockList.Count)
                CurrentIndex = exchangeStockList.Count - 1;
        }

        public static void Select()
        {

        }
    }
}
