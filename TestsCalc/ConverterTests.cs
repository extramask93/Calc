using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace TestsCalc
{
    public class ConverterTests
    {
        [Fact]
        public void TestBaseConversionsDECtoBIN()
        {
            string result = Calculator.Converter.Convert(
                "4", Calculator.InsModeType.DEC,
                Calculator.InsModeType.BIN);
            Assert.Equal("100", result);
        }

        [Fact]
        public void TestBaseConversionsDECtoHEX()
        {
            string result = Calculator.Converter.Convert(
                "255", Calculator.InsModeType.DEC,
                Calculator.InsModeType.HEX);
            Assert.Equal("FF", result);
        }
        [Fact]
        public void TestBaseConversionsDECtoOCT()
        {
            string result = Calculator.Converter.Convert(
                "255", Calculator.InsModeType.DEC,
                Calculator.InsModeType.OCT);
            Assert.Equal("377", result);
        }
        [Fact]
        public void TestBaseConversionsNegativeDECtoHex()
        {
            string result = Calculator.Converter.Convert(
                "-2", Calculator.InsModeType.DEC,
                Calculator.InsModeType.HEX,
                Calculator.WordSizeType.BYTE);
            Assert.Equal("FE", result);
        }

    }
}
