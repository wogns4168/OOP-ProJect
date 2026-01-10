using MoneyWeapon.GameObjects;
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

        private Player _player;
        private MinePotal _minePotal;
        private DengeonPotal _dengeonPotal;
        private ExchangePotal _exchangePotal;
        private TownPotal _townPotal;
        private Player _prevPlayer;

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
            _player = new Player();
            _dengeonPotal = new DengeonPotal();
            _exchangePotal = new ExchangePotal();
            _minePotal = new MinePotal();
            _townPotal = new TownPotal();
            _prevPlayer = new Player();

            SceneManager.AddScene("Title", new TitleScene());
            SceneManager.AddScene("Credit", new CreditScene());
            SceneManager.AddScene("Town", new TownScene(_player, _minePotal, _dengeonPotal, _exchangePotal, _prevPlayer));
            SceneManager.AddScene("Exchange", new ExchangeScene(_player, _townPotal));
            SceneManager.AddScene("Mine", new MineScene());
            SceneManager.AddScene("Dungeon", new DungeonScene());
            SceneManager.AddScene("Ending", new EndingScene());

            SceneManager.Change("Title");
        }
    }
}
