using System;
using Xunit;
using Calculator;
namespace TestsCalc
{
    public class UnitTest1
    {
        [Fact]
        public void CreateCalculatorTest()
        {
            var calc = new Calculator.Calculator();
            Assert.NotNull(calc);
        }

        [Fact]
        public void CreateCalculatorTest_defaultVar()
        {
            var calc = new Calculator.Calculator();
            Assert.Equal("0", calc.ScreenBuffer);
        }
        [Fact]
        public void TestStartingState()
        {
            var calc = new Calculator.Calculator();
            Assert.Equal(WordSizeType.QWORD, calc.State.WordSize);
            Assert.Equal(InsModeType.DEC, calc.State.InsMode);
        }

        [Fact]
        public void CreateCalculatorTestParseString()
        {
            var calc = new Calculator.Calculator();
            calc.ParseInput("4");
            Assert.Equal("4" , calc.ScreenBuffer);
        }


    }
}
