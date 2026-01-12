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
    internal class DungeonScene : Scene
    {
        private Tile[,] dungeonField = new Tile[5, 20];
        private Player _player = new Player();
        private TownPotal _townPotal = new TownPotal();

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
            "[던전]".Print(ConsoleColor.Red);
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
            _player.Position = new Vector(2, 2);
            _townPotal.Position = new Vector(1, 2);
            ObjectPosition(_player);
            ObjectPosition(_townPotal);
            Log.NomalLog("던전씬 진입");
        }

        public override void Exit()
        {
            dungeonField[_player.Position.Y, _player.Position.X].OnTileObject = null;
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
