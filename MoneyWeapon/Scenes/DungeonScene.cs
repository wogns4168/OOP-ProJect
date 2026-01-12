using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class DungeonScene : Scene
    {
        private Tile[,] dungeonField = new Tile[5, 20];
        private Player _player = new Player();
        private Player _prevPlayer = new Player();
        private TownPotal _townPotal = new TownPotal();
        public static Monster _currentMonster;
        public static int _curFloor = 1;
        private int _endingFloor = 10;
        private bool _dungeonClear;
        private bool _resultPickUp;
        private Result result;

        public DungeonScene() => Init();

        public void Init()
        {

            for (int y = 0; y < dungeonField.GetLength(0); y++)
            {
                for (int x = 0; x < dungeonField.GetLength(1); x++)
                {
                    Vector pos = new Vector(x, y);
                    dungeonField[y, x] = new Tile(pos);

                    if (y == 0 || x == 0 || y == dungeonField.GetLength(0) - 1 || x == dungeonField.GetLength(1) - 1)
                    {
                        dungeonField[y, x].OnTileObject = new Wall();
                    }
                }
            }
        }
        public void ObjectPosition(GameObject obj)
        {
            obj.Field = dungeonField;
            dungeonField[obj.Position.Y, obj.Position.X].OnTileObject = obj;
        }

        private void PrintField()
        {
            Console.SetCursorPosition(5, 1);
            Tutorial.Render(5, 1);
            Console.SetCursorPosition(5, 9);
            $"[{_curFloor}층 던전]".Print(ConsoleColor.Red);
            for (int y = 0; y < dungeonField.GetLength(0); y++)
            {
                for (int x = 0; x < dungeonField.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x + 5, y + 10);
                    dungeonField[y, x].Print();
                }
            }
        }

        public override void Enter()
        {
            if (_prevPlayer.Position.X == Vector.None.X && _prevPlayer.Position.Y == Vector.None.Y)
            {
                _player.Position = new Vector(2, 2);
            }
            else
            {
                _player.Position = _prevPlayer.Position;
            }
            if (result == null) _dungeonClear = false;

            _townPotal.Position = new Vector(1, 2);

            if (_currentMonster == null)
            {
                if (!_dungeonClear)
                    SpawnMonster();
            }
            else
            {
                if (_currentMonster.Hp <= 0 && result != null)
                {
                    dungeonField[_currentMonster.Position.Y, _currentMonster.Position.X].OnTileObject = null;
                    _currentMonster = null;
                }
                else
                {
                    ObjectPosition(_currentMonster);
                }
            }
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            Log.NomalLog("던전씬 진입");
        }

        public override void Exit()
        {
            _prevPlayer.Position = _player.Position;
            if (_dungeonClear == true && result == null)
            {
                _curFloor++;
                _prevPlayer.Position = Vector.None;
                _resultPickUp = false;
            }
        }

        public override void Render()
        {
            PrintField();
            _player.Render();
        }

        public override void Update()
        {
            Clear();
            if (_currentMonster == null && !_resultPickUp) SpawnResult();
            _player.Update();

            if (_currentMonster != null)
            {
                if (InputManager.GetKey(ConsoleKey.Spacebar))
                {
                    if (Vector.Near(_player.Position, _currentMonster.Position))
                    {
                        SceneManager.Change("Battle");
                    }
                }
            }

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                if (Vector.Near(_player.Position, _townPotal.Position))
                {
                    SceneManager.Change("Town");
                }

                if (result != null)
                {
                    if (Vector.Near(_player.Position, result.Position))
                    {
                        Inventory.Add(MineScene.richPaper, result.DropNum);
                        dungeonField[result.Position.Y, result.Position.X].OnTileObject = null;
                        _resultPickUp = true;
                        result = null;
                    }
                }

                if (_curFloor == _endingFloor + 1)
                {
                    if(_dungeonClear)
                    SceneManager.Change("Ending");
                }
            }

        }

        private void SpawnMonster()
        {
            int hp = _curFloor * 3 * 1000000;
            _currentMonster = new Monster($"{_curFloor}층 몬스터", hp);
            _currentMonster.Position = new Vector(10, 2);
            ObjectPosition(_currentMonster);
        }

        private void Clear()
        {
            if (_currentMonster != null && _currentMonster.Hp <= 0)
            {
                dungeonField[_currentMonster.Position.Y, _currentMonster.Position.X].OnTileObject = null;
                _currentMonster = null;
                _dungeonClear = true;
            }
        }

        private void SpawnResult()
        {
            result = new Result(_curFloor);
            result.Position = new Vector(13, 2);
            ObjectPosition(result);
        }

    }
}
