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
        private Tile[,] _mineField = new Tile[10, 30];
        private Player _player = new Player();
        private TownPotal _townPotal = new TownPotal();
        public List<Paper> _papers = new List<Paper>();
        public List<RichPaper> _richPapers = new List<RichPaper>();
        private Random _random = new Random();
        public static Stock paper = new Stock("폐지", 3000);
        public static Stock richPaper = new Stock("노다지", 50000);

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
            Console.SetCursorPosition(5, 9);
            "[광산]".Print(ConsoleColor.Red);
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
            _player.Position = new Vector(15, 2);
            _townPotal.Position = new Vector(15, 1);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            SpawnPapers();
            SpawnRichPapers();
            Log.NomalLog("광산씬 진입");
        }

        public override void Exit()
        {
            _mineField[_player.Position.Y, _player.Position.X].OnTileObject = null;
            for (int i = 0; i < _papers.Count; i++)
            {
                _mineField[_papers[i].Position.Y, _papers[i].Position.X].OnTileObject = null;
            }

            for (int i = 0; i < _richPapers.Count; i++)
            {
                _mineField[_richPapers[i].Position.Y, _richPapers[i].Position.X].OnTileObject = null;
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

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                if (Vector.Near(_player.Position, _townPotal.Position))
                {
                    SceneManager.ChangePrevScene();
                }

                for(int i = 0; i < _papers.Count; i++)
                {
                    if(Vector.Near(_player.Position, _papers[i].Position))
                    {
                        Inventory.Add(paper, 1);
                        _mineField[_papers[i].Position.Y, _papers[i].Position.X].OnTileObject = null;
                        _papers.RemoveAt(i);
                    }

                }

                for (int i = 0; i < _richPapers.Count; i++)
                {
                    if (Vector.Near(_player.Position, _richPapers[i].Position))
                    {
                        Inventory.Add(richPaper, 1);
                        _mineField[_richPapers[i].Position.Y, _richPapers[i].Position.X].OnTileObject = null;
                        _richPapers.RemoveAt(i);
                    }
                }

            }
        }

        private void SpawnPapers()
        {
            List<Vector> emptyTiles = new List<Vector>();

            for (int y = 1; y < _mineField.GetLength(0) - 1; y++)
            {
                for (int x = 1; x < _mineField.GetLength(1) - 1; x++)
                {
                    if (_mineField[y, x].OnTileObject == null)
                    {
                        emptyTiles.Add(new Vector(x, y));
                    }
                }
            }

            if (emptyTiles.Count == 0) return;

            int spawnCount = _random.Next(3, 8);

            for (int i = 0; i < spawnCount; i++)
            {
                int index = _random.Next(emptyTiles.Count);
                Vector pos = emptyTiles[index];
                emptyTiles.RemoveAt(index);

                Paper paper = new Paper();
                paper.Position = pos;

                _papers.Add(paper);
                ObjectPosition(paper);
            }
        }

            private void SpawnRichPapers()
        {
            List<Vector> emptyTiles = new List<Vector>();

            for (int y = 1; y < _mineField.GetLength(0) - 1; y++)
            {
                for (int x = 1; x < _mineField.GetLength(1) - 1; x++)
                {
                    if (_mineField[y, x].OnTileObject == null)
                    {
                        emptyTiles.Add(new Vector(x, y));
                    }
                }
            }

            if (emptyTiles.Count == 0) return;

            int spawnCount = _random.Next(-10, 3);

            if (spawnCount < 0) return;

            for (int i = 0; i < spawnCount; i++)
            {
                int index = _random.Next(emptyTiles.Count);
                Vector pos = emptyTiles[index];
                emptyTiles.RemoveAt(index);

                RichPaper richPaper = new RichPaper();
                richPaper.Position = pos;

                _richPapers.Add(richPaper);
                ObjectPosition(richPaper);
            }
        }

    }
}
