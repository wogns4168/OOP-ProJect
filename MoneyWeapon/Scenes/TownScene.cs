using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class TownScene : Scene
    {
        private Tile[,] _townField = new Tile[10, 50];
        private Player _player;
        private Player _prevPlayer;
        private MinePotal _minePotal;
        private DengeonPotal _dengeonPotal;
        private ExchangePotal _exchangePotal;

        public TownScene(Player player, MinePotal minePotal, DengeonPotal dengeonPotal, ExchangePotal exchangePotal, Player prevPlayer) => Init(player, minePotal, dengeonPotal, exchangePotal, prevPlayer);

        public void Init(Player player, MinePotal minePotal, DengeonPotal dengeonPotal, ExchangePotal exchangePotal, Player prevPlayer)
        {
            _player = player;
            _minePotal = minePotal;
            _dengeonPotal = dengeonPotal;
            _exchangePotal = exchangePotal;
            _prevPlayer = prevPlayer;

            for (int y = 0; y < _townField.GetLength(0); y++)
            {
                for (int x = 0; x < _townField.GetLength(1); x++)
                { 
                    Vector pos = new Vector(x, y);
                    _townField[y, x] = new Tile(pos);

                    if (y == 0 || x == 0 || y == _townField.GetLength(0) - 1 || x == _townField.GetLength(1) - 1)
                    {
                        _townField[y, x].OnTileObject = new Wall();
                    }
                }
            }
        }

        public override void Enter()
        {
            _player.Field = _townField;
            _exchangePotal.Field = _townField;
            _dengeonPotal.Field = _townField;
            _minePotal.Field = _townField;
            _prevPlayer.Field = _townField;
            if (_prevPlayer.Position.X == Vector.None.X && _prevPlayer.Position.Y == Vector.None.Y)
            {
                _player.Position = new Vector(1, 4); 
            }
            else
            {
                _player.Position = _prevPlayer.Position;
            }
            _prevPlayer.Position = Vector.None;
            _exchangePotal.Position = new Vector(25, 1);
            _dengeonPotal.Position = new Vector(_townField.GetLength(1) - 2, 4);
            _minePotal.Position = new Vector(25, _townField.GetLength(0) - 2);
            ObjectPosition(_player);
            ObjectPosition(_exchangePotal);
            ObjectPosition(_dengeonPotal);
            ObjectPosition(_minePotal);
            Log.NomalLog("마을씬 진입");
        }

        public void ObjectPosition(GameObject obj)
        {
            _townField[obj.Position.Y, obj.Position.X].OnTileObject = obj;
        }

        public override void Exit()
        {
            _prevPlayer.Position = _player.Position;
        }

        public override void Render()
        {
            PrintField();
            _player.Render();
        }

        public override void Update()
        {
            _player.Update();

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                if (Vector.Near(_player.Position, _exchangePotal.Position))
                {
                    SceneManager.Change("Exchange");
                }

                if (Vector.Near(_player.Position, _dengeonPotal.Position))
                {
                    SceneManager.Change("Dengeon");
                }

                if (Vector.Near(_player.Position, _minePotal.Position))
                {
                    SceneManager.Change("Mine");
                }
            }



        }

        private void PrintField()
        {
            Console.SetCursorPosition(5, 1);
            Tutorial.Render(5, 1);
            for (int y = 0; y < _townField.GetLength(0); y++)
            {
                for (int x = 0; x < _townField.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x + 5, y + 10);
                    _townField[y, x].Print();
                }
            }
        }
    }
}
