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
        private TownPotal _townPotal = new TownPotal();
        private List<Monster> _monsters = new List<Monster>();
        private DungeonPotal _dungeonPotal = new DungeonPotal();
        private int _curFloor = 1;
        private int _maxFloor = 10;
        private bool _dungeonClear;
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
            _dungeonClear = false;
            _player.Position = new Vector(2, 2);
            _townPotal.Position = new Vector(1, 2);
            SpawnMonster();
            _monsters[_curFloor - 1].Position = new Vector(10, 2);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            ObjectPosition(_monsters[_curFloor - 1]);
            Log.NomalLog("던전씬 진입");
        }

        public override void Exit()
        {
            dungeonField[_player.Position.Y, _player.Position.X].OnTileObject = null;
            if(_dungeonClear == true)
            {
                _curFloor++;
            }
        }

        public override void Render()
        {
            PrintField();
            _player.Render();
        }

        public override void Update()
        {
            _player.Update();
            Clear();

            if (_dungeonClear == true && result == null)
            {
                SpawnResult();
            }

            if (InputManager.GetKey(ConsoleKey.Spacebar))
            {
                if (Vector.Near(_player.Position, _monsters[_curFloor - 1].Position))
                {
                    SceneManager.Change("Battle");
                }
            }

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                if (Vector.Near(_player.Position, _townPotal.Position))
                {
                    SceneManager.ChangePrevScene();
                }

                if (result != null)
                {
                    if (Vector.Near(_player.Position, result.Position))
                    {
                        Inventory.Add(MineScene.richPaper, result.DropNum);
                        dungeonField[result.Position.Y, result.Position.X].OnTileObject = null;
                    }
                }
            }

            if(PickResult())
            {
                SpawnPotal();
            }

            

        }

        private void SpawnMonster()
        {
            int hp = _curFloor * 3 * 1000000;

            for (int i = 0; i < _maxFloor; i++)
            {
                _monsters.Add(new Monster($"{_curFloor}층 몬스터", hp));
            }
        }

        private void Clear()
        {
            for (int y = 0; y < dungeonField.GetLength(0); y++)
            {
                for (int x = 0; x < dungeonField.GetLength(1); x++)
                {
                    if (dungeonField[y, x].OnTileObject == _monsters[_curFloor - 1]) return;
                }
            }

            _dungeonClear = true;
            dungeonField[_monsters[_curFloor - 1].Position.Y, _monsters[_curFloor - 1].Position.X].OnTileObject = null;
        }

        private void SpawnResult()
        {
            result = new Result(_curFloor);
            result.Position = new Vector(13, 2);
            ObjectPosition(result);
        }

        private void SpawnPotal()
        {
            _dungeonPotal.Position = new Vector(18, 2);
            ObjectPosition(_dungeonPotal);
        }

        private bool PickResult()
        {
            if (result == null) return false;

            if (dungeonField[result.Position.Y, result.Position.X].OnTileObject == null && dungeonField[_monsters[_curFloor - 1].Position.Y, _monsters[_curFloor - 1].Position.X].OnTileObject == null) return true;

            return false;
            
        }
    }
}
