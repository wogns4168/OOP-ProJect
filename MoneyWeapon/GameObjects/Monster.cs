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
        int Hp {  get; }

        public Monster(string name, int hp)
        {
            Name = name;
            Hp = hp;
            Symbol = 'M';
        }
    }
}
