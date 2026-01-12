using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Monster : GameObject
    {
        string Name { get; }
        public int Hp { get; set; }

        public Monster(string name, int hp)
        {
            Name = name;
            Hp = hp;
            Symbol = 'M';
        }

        public void GetAttack(int num)
        {
            int nextHP = Hp -= num;

            if (nextHP < 0) Hp = 0;
            else Hp = nextHP;
        }
    }
}
