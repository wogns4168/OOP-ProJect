using MoneyWeapon.GameObjects;
using MoneyWeapon.Managers;
using MoneyWeapon.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Scenes
{
    internal class BattleScene : Scene
    {
        private double _battleTime;
        private int _fullTime = 30;
        private double _attackCoolTime = 1.5;
        private double _attackTime;

        private Player _player = new Player();
        public override void Enter()
        {
            InputManager.ResetKey();
            Console.Clear();
        }

        public override void Exit()
        {
            _battleTime = 0;
            _attackTime = 0;
            DungeonScene._currentMonster.HpReset();
        }

        public override void Render()
        {
            _battleTime += Time.DeltaTime;
            _attackTime += Time.DeltaTime;
            string timeText = _battleTime.ToString("0.0");
            string attackCoolTime = _attackCoolTime.ToString("0.0");
            string attackTime = _attackTime.ToString("0.0");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine($"현재 쿨타임 : {attackTime} 초 / 공격 쿨타임 : {attackCoolTime} 초");
            Console.SetCursorPosition(2, 21);
            Console.WriteLine($"배틀 경과 시간 : {timeText} 초 / 최대 배틀 시간 : {_fullTime} 초");
            Console.SetCursorPosition(18, 7);
            Console.WriteLine($"플레이어 현재 공격력 : {_player.Attack()}");
            Console.SetCursorPosition(72, 2);
            Console.WriteLine($"몬스터 남은 체력 : {DungeonScene._currentMonster.Hp}");
            Console.SetCursorPosition(77, 3);
            HpBar();
            for (int i = 0; i < MonsterImage.boss.Length; i++)
            {
                Console.SetCursorPosition(70, 5 + i);
                Console.WriteLine(MonsterImage.boss[i]);
            }

            for (int i = 0; i < PlayerImage.playerMoneyAttack.Length; i++)
            {
                Console.SetCursorPosition(20, 9 + i);
                Console.WriteLine(PlayerImage.playerMoneyAttack[i]);
            }

        }

        public override void Update()
        {
            if (DungeonScene._currentMonster == null || 
                DungeonScene._currentMonster.Hp <= 0 || 
                InputManager.GetKey(ConsoleKey.Escape) || _battleTime >= _fullTime)
            {
                SceneManager.Change("Dungeon");
            }


            if (_attackTime >= _attackCoolTime &&
                InputManager.GetKey(ConsoleKey.Spacebar))
            {
                DungeonScene._currentMonster.GetAttack(_player.Attack());
                _attackTime = 0.0;
                InputManager.ResetKey();
            }

        }

        public void HpBar()
        {
            int division = 100000 * 5 * DungeonScene._curFloor;
            int HpBar = DungeonScene._currentMonster.Hp / division;
            switch (HpBar)
            {
                case 10 :
                    "[■■■■■■■■■■]".Print(ConsoleColor.Red);
                    break;
                case 9:
                    "[■■■■■■■■■□]".Print(ConsoleColor.Red);
                    break;
                case 8:
                    "[■■■■■■■■□□]".Print(ConsoleColor.Red);
                    break;
                case 7:
                    "[■■■■■■■□□□]".Print(ConsoleColor.Red);
                    break;
                case 6:
                    "[■■■■■■□□□□]".Print(ConsoleColor.Red);
                    break;
                case 5:
                    "[■■■■■□□□□□]".Print(ConsoleColor.Red);
                    break;
                case 4:
                    "[■■■■□□□□□□]".Print(ConsoleColor.Red);
                    break;
                case 3:
                    "[■■■□□□□□□]".Print(ConsoleColor.Red);
                    break;
                case 2:
                    "[■■□□□□□□□□]".Print(ConsoleColor.Red);
                    break;
                case 1:
                    "[■□□□□□□□□□]".Print(ConsoleColor.Red);
                    break;
            }

        }
    }
}
