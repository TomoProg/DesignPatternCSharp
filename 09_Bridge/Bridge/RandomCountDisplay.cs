using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class RandomCountDisplay : CountDisplay
    {
        public RandomCountDisplay(DisplayImpl impl) : base(impl) { }
        public void RandomDisplay(int min=1, int max=10)
        {
            var seed = (int)(DateTime.Now - new DateTime(2022, 1, 1, 0, 0, 0)).TotalSeconds;    // 時間を基準にシードを作成する
            var r = new Random(seed);
            var num = r.Next(min, max);
            MultiDisplay(num);
        }
    }
}
