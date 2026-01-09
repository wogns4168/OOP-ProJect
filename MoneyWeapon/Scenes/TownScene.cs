using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWeapon.GameObjects;
using MoneyWeapon.Utils;

namespace MoneyWeapon.Scenes
{
    internal class TownScene : Scene
    {
        private Tile[,] _townField = new Tile[10, 50];
        private Player _player;
        private Wall _wall;

        public TownScene(Player player) => Init(player);

        public void Init(Player player)
        {
            _player = player;
            _wall = new Wall();

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
            _player.Position = new Vector(1, 4);
            _townField[_player.Position.Y, _player.Position.X].OnTileObject = _player;
        }

        public override void Exit()
        {
            _townField[_player.Position.Y, _player.Position.X].OnTileObject = null;
            _player.Field = null;
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
