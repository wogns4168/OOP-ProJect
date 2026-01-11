using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static int CurrentIndex { get; set; }

        private static List<string> InventoryList = new List<string>();
        public static void Render(int x, int y)
        {
            if (!IsActive) return;

            int contentHeight = MaxHeight - 3;
            int start = Math.Max(0, InventoryList.Count - contentHeight);

            _outline.X = x + 20;
            _outline.Y = y;
            _outline.Width = 40;
            _outline.Height = 3 + InventoryList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 21, y + 1);
            "[인벤토리]".Print(ConsoleColor.Red);



            for (int i = start; i < InventoryList.Count; i++)
            {
                string text = InventoryList[i];

                Console.SetCursorPosition(x + 22, y + 2 + (i - start));

                if (i == CurrentIndex)
                {
                    "->".Print(ConsoleColor.Green);
                    InventoryList[i].Print(ConsoleColor.Green);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    InventoryList[i].Print();
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
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                SelectUp();
            }

            if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
                SelectDown();
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

        public static void Add(string item)
        {
            InventoryList.Add(item);
        }
    }
}
