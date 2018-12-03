using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Parser
{
    public enum Token
    {
        EOF,
        Add,
        Sub,
        Num,
        Lsh,
        Rsh,
        Or,
        Xor,
        Not,
        And,
        Mod,
        Mul,
        Div,
        Pleft,
        PRight,
    }

    public class Tokenizer
    {
        private TextReader _reader;
        private char _currernChar;
        private Token _currentToken;
        private long _number;
        public Token CurrenToken => _currentToken;
        public Int64 Number => _number;

        public Tokenizer(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextToken();
        }

        private void NextChar()
        {
            int ch = _reader.Read();
            _currernChar = ch < 0 ? '\0' : (char) ch;
        }
        public void NextToken()
        {
            while (char.IsWhiteSpace(_currernChar))
            {
                NextChar();
            }

            switch (_currernChar)
            {
                case '\0':
                    _currentToken = Token.EOF;
                    return;
                case '+':
                    NextChar();
                    _currentToken = Token.Add;
                    return;
                case '-':
                    NextChar();
                    _currentToken = Token.Sub;
                    return;
            }

            if (char.IsDigit(_currernChar))
            {
                var sb = new StringBuilder();
                while (char.IsDigit(_currernChar))
                {
                    sb.Append(_currernChar);
                    NextChar();
                }

                _number = Int64.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                _currentToken = Token.Num;
                return;
            }
            throw new InvalidDataException($"Unexpected character {_currernChar}");
        }

    }
}
