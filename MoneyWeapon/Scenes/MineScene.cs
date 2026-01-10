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
    internal class MineScene : Scene
    {
        private Tile[,] _mineField = new Tile[20, 40];
        private Player _player = new Player();
        private TownPotal _townPotal = new TownPotal();

        public MineScene() => Init();

        public void Init()
        {

            for (int y = 0; y < _mineField.GetLength(0); y++)
            {
                for (int x = 0; x < _mineField.GetLength(1); x++)
                {
                    Vector pos = new Vector(x, y);
                    _mineField[y, x] = new Tile(pos);

                    if (y == 0 || x == 0 || y == _mineField.GetLength(0) - 1 || x == _mineField.GetLength(1) - 1)
                    {
                        _mineField[y, x].OnTileObject = new Wall();
                    }
                }
            }

        }
        public void ObjectPosition(GameObject obj)
        {
            obj.Field = _mineField;
            _mineField[obj.Position.Y, obj.Position.X].OnTileObject = obj;
        }

        private void PrintField()
        {
            Console.SetCursorPosition(5, 1);
            Tutorial.Render(5, 1);
            for (int y = 0; y < _mineField.GetLength(0); y++)
            {
                for (int x = 0; x < _mineField.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x + 5, y + 10);
                    _mineField[y, x].Print();
                }
            }
        }

        public override void Enter()
        {
            _player.Position = new Vector(20, 2);
            _townPotal.Position = new Vector(20, 1);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            Log.NomalLog("광산씬 진입");
        }

        public override void Exit()
        {
            _mineField[_player.Position.Y, _player.Position.X].OnTileObject = null;
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
                if (Vector.Near(_player.Position, _townPotal.Position))
                {
                    SceneManager.ChangePrevScene();
                }
            }
        }

    }
}
