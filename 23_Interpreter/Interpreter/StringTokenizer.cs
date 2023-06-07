using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class StringTokenizer
    {
        public readonly string Text;
        private string[] _tokens;
        private int _tokensIndex;

        public StringTokenizer(string text)
        {
            Text = text;
            _tokens = text.Split(
                new char[] { ' ', '\n', '\t' }  // NOTE: 文字列とか使うようになるとスペースでsplitしてるとうまくいかなさそう...
                , StringSplitOptions.RemoveEmptyEntries
                );
            _tokensIndex = 0;
        }

        public bool HasMoreTokens()
        {
            return _tokens.Length > _tokensIndex;
        }

        public string NextToken()
        {
            var result = _tokens[_tokensIndex];
            _tokensIndex++;
            return result;
        }
    }
}