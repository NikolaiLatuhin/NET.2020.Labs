using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Core
{
    public class MatrixDimensionsIncorrectException : Exception
    {
        public int Matrix1Rows { get; }
        public int Matrix1Columns { get; }
        public int Matrix2Rows { get; }
        public int Matrix2Columns { get; }
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
            Matrix1Rows = matrix1.Rows;
            Matrix1Columns = matrix1.Columns;
            Matrix2Rows = matrix2.Rows;
            Matrix2Columns = matrix2.Columns;

            InformationDimension = $"Dimensions first matrix [{Matrix1Rows}, {Matrix1Columns}]" +
                                   $"\nDimensions second matrix [{Matrix2Rows}, {Matrix2Columns}]";
        }

        public MatrixDimensionsIncorrectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
