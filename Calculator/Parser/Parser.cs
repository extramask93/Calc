using Calc.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string str)
            :base(str)
        {
        }
    }
    public class Parser
    {
        private Tokenizer _tokenizer;

        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        public Node ParseExpression()
        {
            var expr = ParseAddSubtract();
            if (_tokenizer.CurrenToken != Token.EOF)
                throw new SyntaxException("Unexpected characters at the end of expression");
            return expr;
        }
        Node ParseAddSubtract()
        {
            var lhs = ParseUnary();
            while(true)
            {
                Func<long, long, long> op = null;

                if (_tokenizer.CurrenToken == Token.Add)
                {
                    op = (a, b) => a + b;
                }
                else if(_tokenizer.CurrenToken == Token.Sub)
                {
                    op = (a, b) => a - b;
                }
                else if(_tokenizer.CurrenToken==Token.Or)
                {
                    op = (a, b) => a | b;
                }
                else if (_tokenizer.CurrenToken == Token.And)
                {
                    op = (a, b) => a & b;
                }
                else if (_tokenizer.CurrenToken == Token.Xor)
                {
                    op = (a, b) => a ^ b;
                }
                else if (_tokenizer.CurrenToken == Token.Rsh)
                {
                    op = (a, b) => a >> (int)b;
                }
                else if (_tokenizer.CurrenToken == Token.Lsh)
                {
                    op = (a, b) => a << (int)b;
                }
                else if (_tokenizer.CurrenToken == Token.Mod)
                {
                    op = (a, b) => a % b;
                }
                else if (_tokenizer.CurrenToken == Token.Mul)
                {
                    op = (a, b) => a * b;
                }
                else if (_tokenizer.CurrenToken == Token.Div)
                {
                    op = (a, b) => a / b;
                }
                if (op == null)
                {
                    return lhs;
                }
                _tokenizer.NextToken();
                var rhs = ParseUnary();
                lhs = new NodeBinary(lhs, rhs, op);
            }
        }
        Node ParseLeaf()
        {
            if (_tokenizer.CurrenToken == Token.Pleft)
            {
                _tokenizer.NextToken();
                var node = ParseAddSubtract();
                if (_tokenizer.CurrenToken != Token.PRight)
                    throw new SyntaxException("Missing closing parethese");
                _tokenizer.NextToken();
                return node;
            }
            if (_tokenizer.CurrenToken == Token.Num)
            {
                var node = new NodeNum(_tokenizer.Number);
                _tokenizer.NextToken();
                return node;
            }
            throw new SyntaxException($"Unexpected token: {_tokenizer.CurrenToken}");
        }
        Node ParseUnary()
        {
            if(_tokenizer.CurrenToken == Token.Add)
            {
                _tokenizer.NextToken();
                return ParseUnary();
            }
            if(_tokenizer.CurrenToken == Token.Sub)
            {
                _tokenizer.NextToken();
                var rhs = ParseUnary();
                return new NodeUnary(rhs, (a) => -a);
            }
            if(_tokenizer.CurrenToken == Token.Not)
            {
                _tokenizer.NextToken();
                var rhs = ParseUnary();
                return new NodeUnary(rhs, (a) => ~a);
            }
            return ParseLeaf();
        }
        public static Node Parse(string str)
        {
            return Parse(new Tokenizer(new StringReader(str)));
        }
        public static Node Parse(Tokenizer tokenizer)
        {
            var parser = new Parser(tokenizer);
            return parser.ParseExpression();
        }
    }
}
