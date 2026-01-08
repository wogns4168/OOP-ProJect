using MoneyWeapon.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Managers
{
    internal class GameManager
    {
        public const string SubGameTitle = "마왕 잡기 전에 손절부터...";
        public static bool IsGameOver {  get; set; }

        public void Run()
        {
            Init();

            while(!IsGameOver)
            {
                Console.Clear();
                SceneManager.Render();

                InputManager.GetUserInput();

                SceneManager.Update();
            }

        }

        public void Init()
        {
            IsGameOver = false;

            SceneManager.AddScene("Title", new TitleScene());

            SceneManager.Change("Title");
        }
    }
}
