using MoneyWeapon.Scenes;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Log.Render(40, 10);

                InputManager.GetUserInput();

                if (InputManager.GetKey(ConsoleKey.L))
                {
                    Log.HandleControl();
                }

                SceneManager.Update();
            }

        }

        public void Init()
        {
            IsGameOver = false;

            SceneManager.AddScene("Title", new TitleScene());
            SceneManager.AddScene("Credit", new TitleScene());
            SceneManager.AddScene("Town", new TitleScene());
            SceneManager.AddScene("Exchange", new TitleScene());
            SceneManager.AddScene("Mine", new TitleScene());
            SceneManager.AddScene("Dungeon", new TitleScene());
            SceneManager.AddScene("Ending", new TitleScene());

            SceneManager.Change("Title");
        }
    }
}
