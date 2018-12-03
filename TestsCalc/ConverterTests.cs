using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Calc;
namespace TestsCalc
{
    public class ConverterTests
    {
        [Fact]
        public void TestBaseConversionsDECtoBIN()
        {
            string result = Calc.Converter.Convert(
                "4", Calc.IMType.DEC,
                Calc.IMType.BIN);
            Assert.Equal("100", result);
        }

        [Fact]
        public void TestBaseConversionsDECtoHEX()
        {
            string result = Calc.Converter.Convert(
                "255", Calc.IMType.DEC,
                Calc.IMType.HEX);
            Assert.Equal("FF", result);
        }
        [Fact]
        public void TestBaseConversionsDECtoOCT()
        {
            string result = Calc.Converter.Convert(
                "255", Calc.IMType.DEC,
                Calc.IMType.OCT);
            Assert.Equal("377", result);
        }
        [Fact]
        public void TestBaseConversionsNegativeDECtoHex()
        {
            string result = Calc.Converter.Convert(
                "-2", Calc.IMType.DEC,
                Calc.IMType.HEX,
                Calc.WSType.BYTE);
            Assert.Equal("FE", result);
        }

    }
}
