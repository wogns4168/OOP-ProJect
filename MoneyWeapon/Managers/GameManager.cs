using MoneyWeapon.GameObjects;
using MoneyWeapon.Scenes;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyWeapon.Managers
{
    internal class GameManager
    {
        public const string SubGameTitle = "마왕 잡기 전에 손절부터...";
        public static bool IsGameOver {  get; set; }
        private Time _time;

        private Player _player;
        private MinePotal _minePotal;
        private DungeonPotal _dungeonPotal;
        private ExchangePotal _exchangePotal;
        private TownPotal _townPotal;
        private Player _prevPlayer;
        private Guide _gudie;

        public void Run()
        {
            Init();

            while(!IsGameOver)
            {
                _time.Tick();
                if(!(SceneManager.curScene() is BattleScene)) Console.Clear();
                SceneManager.Render();
                _gudie.Render();
                Log.Render(40, 10);
                Inventory.Render(40, 10);

                InputManager.GetUserInput();

                if (ExchangeScene.exchangeIsActive == false)
                {
                    if (InputManager.GetKey(ConsoleKey.L))
                    {
                        Log.HandleControl();
                    }

                    if (!(SceneManager.curScene() is TitleScene) && Log.IsActive == false )
                    {
                        if (InputManager.GetKey(ConsoleKey.I))
                        {
                            Inventory.HandleControl();
                        }
                    }
                }

                if (Inventory.IsActive)
                {
                    Inventory.Update();
                }

                SceneManager.Update();
            }

        }

        public void Init()
        {
            _time = new Time();
            IsGameOver = false;
            _player = new Player();
            _dungeonPotal = new DungeonPotal();
            _exchangePotal = new ExchangePotal();
            _minePotal = new MinePotal();
            _townPotal = new TownPotal();
            _prevPlayer = new Player();
            _gudie = new Guide();

            SceneManager.AddScene("Title", new TitleScene());
            SceneManager.AddScene("Credit", new CreditScene());
            SceneManager.AddScene("Town", new TownScene());
            SceneManager.AddScene("Exchange", new ExchangeScene());
            SceneManager.AddScene("Mine", new MineScene());
            SceneManager.AddScene("Dungeon", new DungeonScene());
            SceneManager.AddScene("Ending", new EndingScene());
            SceneManager.AddScene("Battle", new BattleScene());

            SceneManager.Change("Title");
        }
    }
}
