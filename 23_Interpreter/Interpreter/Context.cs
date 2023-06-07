using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Context
    {
        private StringTokenizer _tokenizer;
        private string _currentToken;

        public Context(string text)
        {
            _tokenizer = new StringTokenizer(text);
        }

        public string NextToken()
        {
            if(_tokenizer.HasMoreTokens())
            {
                _currentToken = _tokenizer.NextToken();
            }
            else
            {
                _currentToken = null;
            }
            return _currentToken;
        }

        public string CurrentToken()
        {
            return _currentToken;
        }

        public void SkipToken(string token)
        {
            if(token != _currentToken)
            {
                throw new Exception($"{token} is expected, but {_currentToken} is found");
            }
            NextToken();
        }

        public int CurrentNumber()
        {
            int number = 0;
            number = int.Parse(_currentToken);
            return number;
        }

    }
}
