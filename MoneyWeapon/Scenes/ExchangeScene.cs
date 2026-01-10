using MoneyWeapon.GameObjects;
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
        private Player _player;
        private TownPotal _townPotal;

        public ExchangeScene(Player player, TownPotal townPotal) => Init(player, townPotal);

        public void Init(Player player, TownPotal townPotal)
        {
            _player = player;
            _townPotal = townPotal;

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
            _player.Field = _exchangeField;
            _townPotal.Field = _exchangeField;
            _player.Position = new Vector(9, 7);
            _townPotal.Position = new Vector(9, 8);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            Log.NomalLog("거래소씬 진입");
        }

        public override void Exit()
        {
        }

        public override void Render()
        {
            PrintField();
            _player.Render();
        }

        public override void Update()
        {
            _player.Update();
        }
    }
}
