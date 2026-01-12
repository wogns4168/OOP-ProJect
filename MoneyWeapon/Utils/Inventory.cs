using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Scenes;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using static MoneyWeapon.Utils.Log;

namespace MoneyWeapon.Utils
{
    internal class Inventory
    {

        public static bool IsActive { get; set; }
        private static Ractangle _outline;
        const int MaxHeight = 15;
        public static event Action<int> Onselect;

        private static int CurrentIndex { get; set; }

        public static List<InventorySlot> InventoryList = new List<InventorySlot>();

        public static void Add(Stock stock, int number)
        {
            InventorySlot slot = null;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if (stock == InventoryList[i].stock)
                {
                    slot = InventoryList[i];
                    break;
                }
            }

            if(slot == null)
            {
                InventoryList.Add(new InventorySlot(stock, number));
            }
            else
            {
                slot.Quantity += number;
            }
        }

        public static void Remove(Stock stock, int number)
        {
            InventorySlot slot = null;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if (stock == InventoryList[i].stock)
                {
                    slot = InventoryList[i];
                    break;
                }
            }

            if (slot == null) return;

            else
            {
                if (slot.Quantity < number) return;
                else if (slot.Quantity == number) InventoryList.Remove(slot);
                else slot.Quantity -= number;
            }
        }

        public static int AllPrice()
        {
            int allPrice = 0;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                InventorySlot slot = InventoryList[i];
                allPrice += slot.Quantity * slot.stock.Price;
            }
            return allPrice;
        }
        public static void Render(int x, int y)
        {
            if (!IsActive) return;

            int contentHeight = MaxHeight - 3;
            int start = Math.Max(0, InventoryList.Count - contentHeight);

            _outline.X = x + 20;
            _outline.Y = y;
            _outline.Width = 50;
            _outline.Height = 4 + InventoryList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 21, y + 1);
            "[인벤토리]".Print(ConsoleColor.Red);
            Console.SetCursorPosition(x + 45, y + 1);
            $"총 금액 : {AllPrice()}".Print(ConsoleColor.Green);
            Console.SetCursorPosition(x + 23, y + 2);
            "[이름]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 35, y + 2);
            "[보유]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 47, y + 2);
            "[가격]".Print(ConsoleColor.Yellow);
            Console.SetCursorPosition(x + 59, y + 2);
            "[평단가]".Print(ConsoleColor.Yellow);




            for (int i = start; i < InventoryList.Count; i++)
            {
                var item = InventoryList[i];

                int X = _outline.X + 2;
                int Y = _outline.Y + 3 + (i - start);

                Console.SetCursorPosition(X, Y);

                if (i == CurrentIndex)
                {
                    "->".Print(ConsoleColor.Green);
                    item.stock.Name.Print(ConsoleColor.Green);
                    Console.SetCursorPosition(X + 23, Y);
                    Console.WriteLine(item.stock.Price);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    item.stock.Name.Print();
                    Console.SetCursorPosition(X + 23, Y);
                    Console.WriteLine(item.stock.Price);
                }
            }

        }

        public static void HandleControl()
        {
            Log.NomalLog("인벤토리 활성화 / 비 활성화");
            IsActive = !IsActive;
            Player.IsActive = !IsActive;
        }

        public static void Update()
        {

            if (ExchangeScene.IsInventoryUse == true)
            {
                if (InputManager.GetKey(ConsoleKey.UpArrow))
                {
                    SelectUp();
                }

                if (InputManager.GetKey(ConsoleKey.DownArrow))
                {
                    SelectDown();
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

            if (CurrentIndex >= InventoryList.Count)
                CurrentIndex = InventoryList.Count - 1;
        }

        public static void Select()
        {
            Onselect?.Invoke(CurrentIndex);
        }

        public static int GetQuantity(Stock stock)
        {
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if(stock == InventoryList[i].stock)
                {
                    return InventoryList[i].Quantity;
                }
            }
            return 0;
        }
    }
}
