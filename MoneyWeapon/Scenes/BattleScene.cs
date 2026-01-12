using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class BattleScene : Scene
    {
        public override void Enter()
        {
        }

        public override void Exit()
        {
            if (InputManager.GetKey(ConsoleKey.Escape))
            {
                SceneManager.ChangePrevScene();
            }
        }

        public override void Render()
        {
        }

        public override void Update()
        {
        }
    }
}
