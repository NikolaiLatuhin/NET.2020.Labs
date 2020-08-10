using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdFind.Core.Tests
{
    [TestClass]
    public class GcdFinderSteinTests
    {
        [TestMethod]
        public void Should_Return16_When_Input64and48()
        {
            // arrange
            var a = 64;
            var b = 48;
            var expected = 16;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return16_When_Input48and64()
        {
            // arrange
            var a = 48;
            var b = 64;
            var expected = 16;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Should_ReturnExpected_When_InputBothNumbersZero()
        {
            var a = 0;
            var b = 0;

            GcdFinder.FindWithStein(a, b);
        }


        [TestMethod]
        public void Should_Return5_When_Input5and0()
        {
            // arrange
            var a = 5;
            var b = 0;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return5_When_Input0and5()
        {
            // arrange
            var a = 0;
            var b = 5;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightResult_When_InputNegativeFirstNumberAndPositiveSecondNumber()
        {
            // arrange
            var a = -5;
            var b = 10;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightResult_When_InputNegativeSecondNumberAndPositiveFirstNumber()
        {
            // arrange
            var a = 5;
            var b = -10;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightResult_When_InputNegativeBothNumbers()
        {
            // arrange
            var a = -5;
            var b = -10;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return48_When_Input48and48()
        {
            // arrange
            var a = 48;
            var b = 48;
            var expected = 48;

            // act
            var actual = GcdFinder.FindWithStein(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
