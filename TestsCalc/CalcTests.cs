using System;
using Xunit;
using Calc;

namespace TestsCalc
{
    public class CalcTests
    {
        [Fact]
        public void CreateCalculatorTest()
        {
            var calc = new Calc.Calculator();
            Assert.NotNull(calc);
        }

        [Fact]
        public void CreateCalculatorTest_defaultVar()
        {
            var calc = new Calc.Calculator();
            Assert.Equal("0", calc.ScreenBuffer);
        }
        [Fact]
        public void TestStartingState()
        {
            var calc = new Calculator();
            Assert.Equal(WSType.QWORD, calc.State.Ws);
            Assert.Equal(IMType.DEC, calc.State.Im);
        }

        [Fact]
        public void CreateCalculatorTestParseString()
        {
            var calc = new Calculator();
            calc.ParseInput("4");
            Assert.Equal("4" , calc.ScreenBuffer);
        }


    }
}
