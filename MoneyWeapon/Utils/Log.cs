using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal static class Log
    {
        public static bool IsActive { get; set; }
        private static Ractangle _outline;
        const int MaxHeight = 15;

        public enum LogType
        {
            Nomal,
            Warning
        }

        private static List<(LogType type, string text)> LogList = new List<(LogType type, string text)>();

        public static void NomalLog(string text)
        {
            LogList.Add((LogType.Nomal, text));
        }

        public static void WarningLog(string text)
        {
            LogList.Add((LogType.Warning, text));
        }

        public static void Render(int x, int y)
        {
            if (!IsActive) return;

            int contentHeight = MaxHeight - 3;
            int start = Math.Max(0, LogList.Count - contentHeight);

            _outline.X = x + 20;
            _outline.Y = y;
            _outline.Width = 40;
            _outline.Height = 3 + LogList.Count - start;
            _outline.Draw();

            Console.SetCursorPosition(x + 21, y + 1);
            "[Log 목록]".Print(ConsoleColor.Red);

           

            for (int i = start; i < LogList.Count; i++)
            {
                var (type, text) = LogList[i];

                Console.SetCursorPosition(x + 22, y + 2 + (i - start));

                if (type == LogType.Nomal)
                    text.Print();
                else
                    text.Print(ConsoleColor.Yellow);

                Console.WriteLine();
            }

        }

        public static void HandleControl()
        {
            IsActive = !IsActive;
        }
    }
}
