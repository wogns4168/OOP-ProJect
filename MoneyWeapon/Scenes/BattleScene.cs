using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class BattleScene : Scene
    {
        private double _battleTime;
        private double _attackCoolTime = 1.5;
        private double _attackTime;

        private Player _player = new Player();
        public override void Enter()
        {
        }

        public override void Exit()
        {
            _battleTime = 0;
            _attackTime = 0;
        }

        public override void Render()
        {
            _battleTime += Time.DeltaTime;
            _attackTime += Time.DeltaTime;
            string timeText = _battleTime.ToString("0.0");
            string attackCoolTime = _attackCoolTime.ToString("0.0");
            string attackTime = _attackTime.ToString("0.0");
            Console.SetCursorPosition(0, 19);
            Console.WriteLine($"현재 쿨타임 : {attackTime} 초 / 공격 쿨타임 : {attackCoolTime} 초");
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"배틀 경과 시간 : {timeText} 초 / 최대 배틀 시간 : 60 초");
        }

        public override void Update()
        {
            if (DungeonScene._currentMonster == null || DungeonScene._currentMonster.Hp <= 0 || InputManager.GetKey(ConsoleKey.Escape) || _battleTime >= 10)
            {
                SceneManager.ChangePrevScene();
            }

            if(InputManager.GetKey(ConsoleKey.Spacebar))
            {
                if (_attackTime > _attackCoolTime)
                {
                    DungeonScene._currentMonster.GetAttack(_player.Attack());
                    _attackTime = 0.0;
                }
            }

        }
    }
}
