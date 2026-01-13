using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal class MenuList
    {
        private List<(string text, Action action)> _menus;
        public int CurrentIndex { get; private set; }
        private Ractangle _outline;
        private int _maxLength;



        public MenuList(params (string, Action)[] menuTexts)
        {
            if (menuTexts.Length == 0)
            {
                _menus = new List<(string, Action)>();
            }
            else
            {
                _menus = menuTexts.ToList();
            }

            for (int i = 0; i < _menus.Count; i++)
            {
                int textWidth = _menus[i].text.GetTextWidth();

                if (_maxLength < textWidth)
                {
                    _maxLength = textWidth;
                }
            }

            _outline = new Ractangle(width: _maxLength + 4, height: _menus.Count + 2);
        }

        public void Reset()
        {
            CurrentIndex = 0;
        }

        public void Select()
        {
            if (_menus.Count == 0) return;

            _menus[CurrentIndex].action?.Invoke();

            if (_menus.Count == 0) CurrentIndex = 0;
            else if (CurrentIndex >= _menus.Count) CurrentIndex = _menus.Count - 1;
        }

        public void Add(string text, Action action)
        {
            _menus.Add((text, action));

            int textWidth = text.GetTextWidth();
            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }

            _outline.Width = _maxLength + 6;
            _outline.Height++;
        }

        public void Remove()
        {
            _menus.RemoveAt(CurrentIndex);

            int max = 0;

            foreach ((string text, Action action) in _menus)
            {
                int textWidth = text.GetTextWidth();

                if (max < textWidth) max = textWidth;

            }

            if (_maxLength != max) _maxLength = max;

            _outline.Width = _maxLength + 6;
            _outline.Height--;
        }

        public void Render(int x, int y)
        {
            _outline.X = x;
            _outline.Y = y;
            _outline.Draw();

            for (int i = 0; i < _menus.Count; i++)
            {
                y++;
                Console.SetCursorPosition(x + 1, y);

                if (i == CurrentIndex)
                {
                    "->".Print(ConsoleColor.Green);
                    _menus[i].text.Print(ConsoleColor.Green);
                    continue;
                }
                else
                {
                    Console.Write("  ");
                    _menus[i].text.Print();
                }
            }
        }

        public void GuideRender(int x, int y)
        {
            _outline.X = x;
            _outline.Y = y;
            _outline.Width = _maxLength + 6;
            _outline.Height = _menus.Count + 2;
            _outline.Draw();

            for (int i = 0; i < _menus.Count; i++)
            {
                y++;
                Console.SetCursorPosition(x + 1, y);
                if (i == 0) _menus[i].text.Print(ConsoleColor.Red);
                else
                {
                    Console.Write("  ");
                    _menus[i].text.Print();
                }

            }
        }

        public void SelectUp()
        {
            CurrentIndex--;

            if (CurrentIndex < 0)
                CurrentIndex = 0;
        }

        public void SelectDown()
        {
            CurrentIndex++;

            if (CurrentIndex >= _menus.Count)
                CurrentIndex = _menus.Count - 1;
        }
    }
}
