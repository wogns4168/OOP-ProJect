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
        public static int MaxRandom = 10;
        public static int CurRandom = 0;
        public static int CurRandomPlus = 0;
        public static int CurRandomMax = 3;
        

        private static int CurrentIndex { get; set; }

        private static List<Stock> exchangeStockList = new List<Stock>();

        public ExchangeScene() => Init();

        public void Init()
        {
            exchangeStockList.Add(new Stock("경일", 10000000));
            exchangeStockList.Add(new Stock("라이엇", 5000000));
            exchangeStockList.Add(new Stock("스팀", 1000000));
            exchangeStockList.Add(new Stock("네오플", 700000));
            exchangeStockList.Add(new Stock("카카오", 500000));
            exchangeStockList.Add(new Stock("컴투스", 300000));
            exchangeStockList.Add(new Stock("넥슨", 100000));
            exchangeStockList.Add(new Stock("NC", 50000));
            exchangeStockList.Add(new Stock("넷마블", 30000));
            exchangeStockList.Add(new Stock("크래프톤", 10000));
            exchangeStockList.Add(new Stock("스마일", 5000));
            exchangeStockList.Add(new Stock("펄어비스", 1000));
        }

        public override void Enter()
        {
            exchangeIsActive = true;
            Inventory.IsActive = true;
            IsExchangeUse = true;
            IsInventoryUse = false;
            Log.IsActive = false;
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

            Console.SetCursorPosition(x + 6, y - 2);
            $"폐지 판매 횟수 : [{CurRandomPlus}] 회 / 랜덤 횟수 증가 : [{CurRandomMax}] 회".Print(ConsoleColor.Green);
            Console.SetCursorPosition(x + 6, y - 1);
            $"현재 랜덤 횟수 : [{CurRandom}] 회 / 최대 랜덤 횟수 : [{MaxRandom}] 회".Print(ConsoleColor.Green);
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

                if (i == CurrentIndex && IsExchangeUse == true)
                {
                    "->".Print(ConsoleColor.Green);
                    item.Name.Print(ConsoleColor.Green);
                    Console.SetCursorPosition(X + 15, Y);
                    Console.WriteLine($"{item.Price} 원");
                    Console.SetCursorPosition(X + 33, Y);
                    RatePersent(item);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    item.Name.Print();
                    Console.SetCursorPosition(X + 15, Y);
                    Console.WriteLine($"{item.Price} 원");
                    Console.SetCursorPosition(X + 33, Y);
                    RatePersent(item);
                }
            }

        }

        public override void Update()
        {
            if (InputManager.GetKey(ConsoleKey.Escape))
            {
                SceneManager.ChangePrevScene();
            }

            if (InputManager.GetKey(ConsoleKey.R))
            {
                if(CurRandom < MaxRandom)
                RandomStock();
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
            if (stock == MineScene.paper) CurRandomPlus++;
            if (stock == MineScene.richPaper) MaxRandom++;

            Player.Money += stock.Price * number;
            Inventory.Remove(stock, number);
            RandomPlus();
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
                    Buy(exchangeStockList[CurrentIndex], 1);
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

        public static void RandomStock()
        {
            foreach(var item in exchangeStockList)
            {
                item.RandomPrice();
            }
            CurRandom++;
        }

        private static void RatePersent(Stock stock)
        {
            string rateText = stock.ChangeRate.ToString("+0.0;-0.0;0.0");

            if (stock.ChangeRate < 0)
            {
                $"{rateText} %".Print(ConsoleColor.Red);
            }
            else
            {
                $"{rateText} %".Print(ConsoleColor.Green);
            }
        }

        private static void RandomPlus()
        {
            if (CurRandomPlus == CurRandomMax)
            {
                MaxRandom++;
                CurRandomPlus = 0;
            }
        }
    }
}
