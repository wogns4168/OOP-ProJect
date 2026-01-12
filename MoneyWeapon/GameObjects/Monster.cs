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

        public int nextHp { get; set; }

        public Monster(string name, int hp)
        {
            Name = name;
            Hp = hp;
            nextHp = hp;
            Symbol = 'M';
        }

        public void GetAttack(int num)
        {
            nextHp -= num;

            if (nextHp < 0) Hp = 0;
        }

        public void HpReset()
        {
            if(nextHp > 0)
            {
                nextHp = Hp;
            }
        }
    }
}
