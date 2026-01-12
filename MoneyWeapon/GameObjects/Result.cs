using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.GameObjects
{
    internal class Result : GameObject
    {
        public int DropNum { get; set; }

        public Result(int num)
        {
            Symbol = 'R';
            DropNum = num * 3;
        }
    }
}
