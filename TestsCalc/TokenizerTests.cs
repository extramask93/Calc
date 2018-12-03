using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Calc.Parser;
using Xunit;

namespace TestsCalc
{
    public class TokenizerTests
    {
        [Fact]
        void CreateTokenizerTest()
        {
            string input = "10+20";
            Tokenizer tokenizer = new Tokenizer(new StringReader(input));
            Assert.Equal(Token.Num, tokenizer.CurrenToken);
            Assert.Equal(10,tokenizer.Number);
            tokenizer.NextToken();
            Assert.Equal(Token.Add,tokenizer.CurrenToken);
        }
    }
}
