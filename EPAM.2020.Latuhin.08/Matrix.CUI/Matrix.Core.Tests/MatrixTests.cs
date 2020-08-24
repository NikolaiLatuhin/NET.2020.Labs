using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix.Core.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Should_ReturnRightSumMatrix_When_InputTwoMatrix()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(3, 3);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, {3, 5, 4} };
            double[,] dataMatrix2 = { { 4, 2, 1 }, { 6, 4, 7 }, {3, 5, 1} };

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);

            var expected = new Matrix(3, 3);
            double[,] dataExpected = { { 9, 7, 8 }, { 10, 6, 17 }, { 6, 10, 5 } };
            expected.FillMatrix(dataExpected);

            // act
            var actual = matrix1 + matrix2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightSubtractMatrix_When_InputTwoMatrix()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(3, 3);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, { 3, 5, 4 } };
            double[,] dataMatrix2 = { { 4, 2, 1 }, { 6, 4, 7 }, { 3, 5, 1 } };

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);

            var expected = new Matrix(3, 3);
            double[,] dataExpected = { { 1, 3, 6 }, { -2, -2, 3 }, { 0, 0, 3 } };
            expected.FillMatrix(dataExpected);

            // act
            var actual = matrix1 - matrix2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnRightMultiplyMatrix_When_InputTwoMatrix()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(3, 3);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, { 3, 5, 4 } };
            double[,] dataMatrix2 = { { 4, 2, 1 }, { 6, 4, 7 }, { 3, 5, 1 } };

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);

            var expected = new Matrix(3, 3);
            double[,] dataExpected = { { 71, 65, 47 }, { 58, 66, 28 }, { 54, 46, 42 } };
            expected.FillMatrix(dataExpected);

            // act
            var actual = matrix1 * matrix2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionsIncorrectException))]
        public void Should_ReturnExceptionDimensionsIncorrect_When_SummaryMatrixWithDifferentDimensions()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(2, 3);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, { 3, 5, 4 } };
            double[,] dataMatrix2 = { { 4, 2, 1 }, { 6, 4, 7 } };

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);
            _ = matrix1 + matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionsIncorrectException))]
        public void Should_ReturnExceptionDimensionsIncorrect_When_SubtractionMatrixWithDifferentDimensions()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(2, 3);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, { 3, 5, 4 } };
            double[,] dataMatrix2 = { { 4, 2, 1 }, { 6, 4, 7 }};

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);
            _ = matrix1 - matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionsIncorrectException))]
        public void Should_ReturnExceptionDimensionsIncorrect_When_MultiplyMatrixWithDifferentDimensions()
        {
            // arrange
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(3, 2);

            double[,] dataMatrix1 = { { 5, 5, 7 }, { 4, 2, 10 }, { 3, 5, 4 } };
            double[,] dataMatrix2 = { { 4, 2 }, { 6, 4 }, { 3, 5 } };

            matrix1.FillMatrix(dataMatrix1);
            matrix2.FillMatrix(dataMatrix2);
            _ = matrix1 * matrix2;
        }
    }
}
