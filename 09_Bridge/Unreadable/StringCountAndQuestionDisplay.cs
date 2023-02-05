using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unreadable
{
    // このクラスはStringCountDisplayのMultiDisplayも使いたいし、StringDisplayのCornerプロパティを変えたい
    public class StringCountAndQuestionDisplay : StringCountDisplay
    {
        public StringCountAndQuestionDisplay(string s, string encName = "Shift_JIS") : base(s, encName) { }

        protected override string Corner => "?";
    }
}
