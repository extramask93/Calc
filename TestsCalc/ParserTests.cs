using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Calculator.Parser;

namespace TestsCalc
{
    public class ParserTests
    {
        [Fact]
        void TestAddSub()
        {
            Assert.Equal(50, Parser.Parse("40+10").Eval());
            Assert.Equal(486, Parser.Parse("1+2+3+500-20").Eval());
            Assert.Equal(30,Parser.Parse("40 + -10").Eval());
        }
        [Fact]
        void TestOring()
        {
            Assert.Equal(6, Parser.Parse("0|2|4").Eval());
        }
        [Fact]
        void TestAnding()
        {
            Assert.Equal(3, Parser.Parse("15&3").Eval());
        }
        [Fact]
        void TestXoring()
        {
            Assert.Equal(12, Parser.Parse("15^3").Eval());
        }
        [Fact]
        void TestNegatig()
        {
            Assert.Equal(-1, Parser.Parse("~0").Eval());
            Assert.Equal(-2, Parser.Parse("~1").Eval());
        }
        [Fact]
        void TestRightShifting()
        {
            Assert.Equal(2, Parser.Parse("8>>2").Eval());
        }
        [Fact]
        void TestLeftShifting()
        {
            Assert.Equal(32, Parser.Parse("8<<2").Eval());
        }
        [Fact]
        void TestMod()
        {
            Assert.Equal(2, Parser.Parse("8%3").Eval());
        }
        [Fact]
        void TestMulDiv()
        {
            Assert.Equal(24, Parser.Parse("8*3").Eval());
            Assert.Equal(2, Parser.Parse("8/3").Eval());
        }
        [Fact]
        void TestParetheses()
        {
            Assert.Equal(900, Parser.Parse("(10 + 20) * 30").Eval());
            Assert.Equal(18, Parser.Parse("2+(8*2)").Eval());
        }
    }
}
