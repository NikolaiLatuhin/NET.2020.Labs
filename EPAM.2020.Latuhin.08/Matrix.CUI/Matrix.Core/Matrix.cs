using System;

namespace Matrix.Core
{
    /// <summary>
    /// Класс для работы с матрицами
    /// </summary>
    public class Matrix
    {
        public int Rows { get;}
        public int Columns { get;}
        private readonly double[,] _matrix;

        /// <summary>
        /// Создание матрицы с заданными размерами
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="columns">Количество столбцов</param>
        public Matrix(int rows, int columns)
        {
            if(rows <= 0 || columns <= 0)
                throw new ArgumentException("Rows and Columns must be greater than zero");
            Rows = rows;
            Columns = columns;
            _matrix = new double[rows, columns];
        }

        /// <summary>
        /// Доступ к элементам матрицы через индексатор
        /// </summary>
        /// <param name="row">Строка матрицы</param>
        /// <param name="column">Столбец матрицы</param>
        /// <returns>Возвращает значение элемента матрицы по индексу</returns>
        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        /// <summary>
        /// Создает нулевую матрицу заданного размера
        /// </summary>
        /// <param name="rows">Строка матрицы</param>
        /// <param name="columns">Столбец матрицы</param>
        /// <returns>Возращает нулевую матрицу </returns>
        public static Matrix GetEmpty(int rows, int columns)
        {
            var matrix = new Matrix(rows, columns);

            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    matrix[i, j] = 0;

            return matrix;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Возвращает матрицу суммы</returns>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new MatrixDimensionsIncorrectException("Matrices must be the same dimensions!", matrix1, matrix2);

            var resultMatrix = new Matrix(matrix1.Rows, matrix1.Columns);

            for (var i = 0; i < resultMatrix.Rows; i++)
                for (var j = 0; j < resultMatrix.Columns; j++)
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

            return resultMatrix;
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Возвращает матрицу разности</returns>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new MatrixDimensionsIncorrectException("Matrices must be the same dimensions!", matrix1, matrix2);

            var resultMatrix = new Matrix(matrix1.Rows, matrix1.Columns);

            for (var i = 0; i < resultMatrix.Rows; i++)
                for (var j = 0; j < resultMatrix.Columns; j++)
                    resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];

            return resultMatrix;
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Возвращает матрицу с произведением</returns>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows || matrix1.Rows != matrix2.Columns)
                throw new MatrixDimensionsIncorrectException("Wrong dimensions of matrices, " +
                                                             "the number of columns of matrix A must match the number of rows of matrix B!", matrix1, matrix2);

            var resultMatrix = GetEmpty(matrix1.Rows, matrix2.Columns);

            for (var i = 0; i < resultMatrix.Rows; i++)
                for (var j = 0; j < resultMatrix.Columns; j++)
                    for (var k = 0; k < matrix1.Columns; k++)
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];

            return resultMatrix;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Matrix))
                return false;

            var inputMatrix = (Matrix) obj;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (_matrix[i, j] != inputMatrix[i, j])
                    {
                        return false; 
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Переопределяет метод для формирования строкого представления матрицы
        /// </summary>
        /// <returns>Возвращает строковое представление матрицы</returns>
        public override string ToString()
        {
            var resultString = "";
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    resultString += $"{_matrix[i, j]}" + " ";
                }
                resultString += "\r\n";
            }
            return resultString;
        }
    }
}
