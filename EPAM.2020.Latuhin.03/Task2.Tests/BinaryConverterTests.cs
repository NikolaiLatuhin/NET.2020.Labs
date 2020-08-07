using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryConvert.Core.Tests
{
    [TestClass]
    public class BinaryConverterTests
    {
        [TestMethod]
        public void Should_Return1111101000_When_Input1000()
        {
            // arrange
            uint numberDecimal = 1000;
            string expected = "1111101000";

            // act
            string actual = BinaryConverter.ToBinaryWithAlgorithm(numberDecimal);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return0_When_Input0()
        {
            // arrange
            uint numberDecimal = 0;
            string expected = "0";

            // act
            string actual = BinaryConverter.ToBinaryWithAlgorithm(numberDecimal);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return1_When_Input1()
        {
            // arrange
            uint numberDecimal = 1;
            string expected = "1";

            // act
            string actual = BinaryConverter.ToBinaryWithAlgorithm(numberDecimal);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
