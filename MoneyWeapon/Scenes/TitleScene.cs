using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class TitleScene : Scene
    {
        private MenuList _titleMenu;

        public TitleScene()
        {
            Init();
        }

        public void Init()
        {
            _titleMenu = new MenuList();
            _titleMenu.Add("게임 시작", GameStart);
            _titleMenu.Add("크레딧", Credit);
            _titleMenu.Add("게임 종료", GameQuit);
        }
        public override void Enter()
        {
            _titleMenu.Reset();
        }

        public override void Exit()
        {
        }

        public override void Render()
        {
            Console.SetCursorPosition(2, 1);
            GameName.gameName.Print(ConsoleColor.DarkBlue);
            Console.SetCursorPosition(1, 8);
            GameManager.SubGameTitle.Print(ConsoleColor.Blue);

            _titleMenu.Render(2, 12);
        }

        public override void Update()
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                _titleMenu.SelectUp();
            }

            if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
                _titleMenu.SelectDown();
            }

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                _titleMenu.Select();
            }
        }

        public void GameStart()
        {
            SceneManager.Change("Town");
        }

        public void Credit()
        {
            SceneManager.Change("Credit");
        }

        public void GameQuit()
        {
            GameManager.IsGameOver = true;
        }
    }
}
