using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public abstract class Item
    {
        protected string _caption;
        public Item(string caption)
        {
            _caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>HTMLの文字列を返す</returns>
        public abstract string MakeHTML();
    }
}
