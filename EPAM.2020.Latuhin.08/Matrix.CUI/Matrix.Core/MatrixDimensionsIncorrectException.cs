using System;

namespace Matrix.Core
{
    public class MatrixDimensionsIncorrectException : Exception
    {
        public int FirstMatrixRows { get; }
        public int FirstMatrixColumns { get; }
        public int SecondMatrixRows { get; }
        public int SecondMatrixColumns { get; }
        public string InformationDimension { get;}

        public MatrixDimensionsIncorrectException()
        {
        }

        public MatrixDimensionsIncorrectException(string message)
            : base(message)
        {
        }

        public MatrixDimensionsIncorrectException(string message, Matrix matrix1, Matrix matrix2)
            : base(message)
        {
            FirstMatrixRows = matrix1.Rows;
            FirstMatrixColumns = matrix1.Columns;
            SecondMatrixRows = matrix2.Rows;
            SecondMatrixColumns = matrix2.Columns;

            InformationDimension = $"Dimensions first matrix [{FirstMatrixRows}, {FirstMatrixColumns}]" +
                                   $"\nDimensions second matrix [{SecondMatrixRows}, {SecondMatrixColumns}]";
        }

        public MatrixDimensionsIncorrectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
