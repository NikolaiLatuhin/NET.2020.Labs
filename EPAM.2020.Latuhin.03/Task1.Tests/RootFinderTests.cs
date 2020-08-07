using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RootFind.Core.Tests
{
    [TestClass]
    public class RootFinderTests
    {
        [TestClass]
        public class RootFinderTest
        {
            [TestMethod]
            public void Should_Return2_When_Input32number5degree()
            {
                // arrange
                double number = 32;
                int degree = 5;
                double precision = 0.0000001;
                double expected = 2;

                // act
                double actual = RootFinder.Newton(number, degree, precision);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Should_Return0_When_Input0number5degree()
            {
                // arrange
                double number = 0;
                int degree = 5;
                double precision = 0.0000001;
                double expected = 0;

                // act
                double actual = RootFinder.Newton(number, degree, precision);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Should_ReturnException_When_InputNegativeNumber()
            {
                double number = -32;
                RootFinder.Newton(number, 5, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Should_ReturnException_When_InputZeroPrecision()
            {
                double precision = 0;
                RootFinder.Newton(-32, 5, precision);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Should_ReturnException_When_InputNegativePrecision()
            {
                double precision = -5;
                RootFinder.Newton(-32, 5, precision);
            }
        }
    }
}
