using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vector.Core.Tests
{
    [TestClass]
    public class Vector3DTests
    {
        [TestMethod]
        public void Should_ReturnRightSumVectors_InputTwoVectors()
        {
            // arrange
            var vec1 = new Vector3D(5, 8, 12);
            var vec2 = new Vector3D(4, 9, 7);
            var expected = new Vector3D(9,17,19);

            // act
            var actual = vec1 + vec2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightDifferenceVectors_InputTwoVectors()
        {
            // arrange
            var vec1 = new Vector3D(5, 8, 12);
            var vec2 = new Vector3D(4, 9, 7);
            var expected = new Vector3D(1, -1, 5);

            // act
            var actual = vec1 - vec2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightMultiplyVectors_InputTwoVectors()
        {
            // arrange
            var vec1 = new Vector3D(4, 8, 14);
            var vec2 = new Vector3D(5, 2, 7);
            var expected = new Vector3D(28, 42, -32);

            // act
            var actual = vec1 * vec2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightScalarProductVectors_InputTwoVectors()
        {
            // arrange
            var vec1 = new Vector3D(4, 8, 14);
            var vec2 = new Vector3D(5, 4, 7);
            var expected = 150;

            // act
            var actual = vec1 % vec2;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
