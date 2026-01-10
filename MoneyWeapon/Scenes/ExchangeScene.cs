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
    internal class ExchangeScene : Scene
    {
        private Tile[,] _exchangeField = new Tile[10, 20];
        private Player _player = new Player();
        private TownPotal _townPotal = new TownPotal();

        public ExchangeScene() => Init();

        public void Init()
        {

            for (int y = 0; y < _exchangeField.GetLength(0); y++)
            {
                for (int x = 0; x < _exchangeField.GetLength(1); x++)
                {
                    Vector pos = new Vector(x, y);
                    _exchangeField[y, x] = new Tile(pos);

                    if (y == 0 || x == 0 || y == _exchangeField.GetLength(0) - 1 || x == _exchangeField.GetLength(1) - 1)
                    {
                        _exchangeField[y, x].OnTileObject = new Wall();
                    }
                }
            }

        }
        public void ObjectPosition(GameObject obj)
        {
            obj.Field = _exchangeField;
            _exchangeField[obj.Position.Y, obj.Position.X].OnTileObject = obj;
        }

        private void PrintField()
        {
            Console.SetCursorPosition(5, 1);
            Tutorial.Render(5, 1);
            for (int y = 0; y < _exchangeField.GetLength(0); y++)
            {
                for (int x = 0; x < _exchangeField.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x + 5, y + 10);
                    _exchangeField[y, x].Print();
                }
            }
        }

        public override void Enter()
        {
            _player.Position = new Vector(9, 7);
            _townPotal.Position = new Vector(9, 8);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            Log.NomalLog("거래소씬 진입");
        }

        public override void Exit()
        {
            _exchangeField[_player.Position.Y, _player.Position.X].OnTileObject = null;
        }

        public override void Render()
        {
            PrintField();
            _player.Render();
        }

        public override void Update()
        {
            _player.Update();

            if(InputManager.GetKey(ConsoleKey.Enter))
            {
                if (Vector.Near(_player.Position, _townPotal.Position))
                {
                    SceneManager.ChangePrevScene();
                }
            }
        }
    }
}
