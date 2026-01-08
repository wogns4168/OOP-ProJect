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
        }

        public override void Exit()
        {
        }

        public override void Render()
        {
            Console.SetCursorPosition(5, 1);
            GameManager.GameName.Print(ConsoleColor.Yellow);

            _titleMenu.Render(8, 5);
        }

        public override void Update()
        {
        }

        public void GameStart()
        {

        }

        public void Credit()
        {

        }

        public void GameQuit()
        {
            GameManager.IsGameOver = true;
        }
    }
}
