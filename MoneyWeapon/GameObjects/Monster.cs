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

        public int MaxHp { get; set; }

        public Monster(string name, int hp)
        {
            Name = name;
            Hp = hp;
            MaxHp = hp;
            Symbol = 'M';
        }

        public void GetAttack(int num)
        {
            Hp -= num;

            if (Hp < 0) Hp = 0;
        }

        public void HpReset()
        {
            if(Hp > 0)
            {
                Hp = MaxHp;
            }
        }
    }
}
