using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Calculator.Parser;
namespace TestsCalc
{
    public class NodeTests
    {
        [Fact]
        void AddTest()
        {
            var expression = new NodeBinary(new NodeNum(50),
                new NodeNum(40), (a, b) => a + b);
            var result = expression.Eval();
            Assert.Equal(90, result);
        }
    }
}
