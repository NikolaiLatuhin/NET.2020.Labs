using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdFind.Core.Tests
{
    [TestClass]
    public class GcdFinderEuclideanTests
    {
        [TestMethod]
        public void Should_Return16_When_Input64and48()
        {
            // arrange
            var a = 64;
            var b = 48;
            var expected = 16;

            // act
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Should_ReturnExpected_When_InputBothNumbersZero()
        {
            var a = 0;
            var b = 0;

            GcdFinder.FindWithEuclidean(a, b);
        }


        [TestMethod]
        public void Should_Return5_When_Input5and0()
        {
            // arrange
            var a = 5;
            var b = 0;
            var expected = 5;

            // act
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

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
            var actual = GcdFinder.FindWithEuclidean(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return4_When_Input12and32and36()
        {
            // arrange
            var a = 12;
            var b = 32;
            var c = 36;
            var expected = 4;

            // act
            var actual = GcdFinder.FindWithEuclidean(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Should_Return6_When_Input78and294and570and36()
        {
            // arrange
            var a = 78;
            var b = 294;
            var c = 570;
            var d = 36;
            var expected = 6;

            // act
            var actual = GcdFinder.FindWithEuclidean(a, b, c, d);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Return2_When_Input78and294and578and36and52()
        {
            // arrange
            var a = 78;
            var b = 294;
            var c = 578;
            var d = 36;
            var e = 52;
            var expected = 2;

            // act
            var actual = GcdFinder.FindWithEuclidean(a, b, c, d, e);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
