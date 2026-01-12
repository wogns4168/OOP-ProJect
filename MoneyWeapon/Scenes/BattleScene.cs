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
    internal class BattleScene : Scene
    {
        private Player _player = new Player();
        public override void Enter()
        {
        }

        public override void Exit()
        {

        }

        public override void Render()
        {

        }

        public override void Update()
        {
            if (DungeonScene._currentMonster != null && DungeonScene._currentMonster.Hp > 0)
            {
                if (InputManager.GetKey(ConsoleKey.Spacebar))
                {
                    int damage = _player.Attack();
                    DungeonScene._currentMonster.GetAttack(damage);
                    Log.NomalLog($"플레이어 공격 : {damage}의 데미지 / 남은 몬스터 HP : {DungeonScene._currentMonster.Hp}");
                }
            }

            if (DungeonScene._currentMonster == null || DungeonScene._currentMonster.Hp <= 0 || InputManager.GetKey(ConsoleKey.Escape))
            {
                SceneManager.ChangePrevScene();
            }
        }
    }
}
