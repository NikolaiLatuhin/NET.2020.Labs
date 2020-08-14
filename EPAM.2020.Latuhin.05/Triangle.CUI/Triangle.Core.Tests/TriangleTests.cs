using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Core.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_CheckSidesWithPositiveValue()
        {
            // arrange
            var a = 5;
            var b = 8;
            var c = 12;
            var expected = true;

            // act
            var actual = Triangles.CheckSides(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_CheckExistenceTriangleWithRightSides()
        {
            // arrange
            var a = 5;
            var b = 8;
            var c = 12;
            var expected = true;

            // act
            var actual = Triangles.CheckExisting(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_CheckSidesWithNegativeOrZeroValue()
        {
            // arrange
            var a = -5;
            var b = 0;
            var c = 12;
            var expected = false;

            // act
            var actual = Triangles.CheckSides(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_CheckExistenceTriangleWithWrongSides()
        {
            // arrange
            var a = 10;
            var b = 25;
            var c = 36;
            var expected = false;

            // act
            var actual = Triangles.CheckExisting(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightPerimeter_When_InputRightValueSides()
        {
            // arrange
            var a = 5;
            var b = 8;
            var c = 12;
            var triangle = Triangles.CreateTriangle(a, b, c);
            var expected = 25;

            // act
            var actual = triangle.FindPerimeter();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightArea_When_InputRightValueSides()
        {
            // arrange
            var a = 6;
            var b = 8;
            var c = 10;
            var triangle = Triangles.CreateTriangle(a, b, c);
            var expected = 24;

            // act
            var actual = triangle.FindArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ReturnException_When_CreateTriangleWithWrongSides()
        {
            // arrange
            var a = -5;
            var b = 0;
            var c = -8;
            Triangles.CreateTriangle(a, b, c);
        }
    }
}
