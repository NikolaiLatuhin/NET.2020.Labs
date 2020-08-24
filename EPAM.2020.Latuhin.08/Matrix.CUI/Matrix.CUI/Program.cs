using System;
using Matrix.Core;

namespace Matrix.CUI
{
    class Program
    {
        static void Main()
        {
            while (true) // Запускаем ввод 
            {
                Console.WriteLine("Enter the number of rows of matrix A");
                var stringRowsA = Console.ReadLine();
                if (!int.TryParse(stringRowsA, out var rowsA) || rowsA <= 0)
                {
                    PrintErrorIncorrectData();
                    continue; // Повторить ввод значения, пока не будет введено корректное значение
                }

                Console.WriteLine("Enter the number of columns of matrix A");
                var stringColumnsA = Console.ReadLine();
                if (!int.TryParse(stringColumnsA, out var columnsA) || columnsA <= 0)
                {
                    PrintErrorIncorrectData();
                    continue; // Повторить ввод значения, пока не будет введено корректное значение
                }

                Console.WriteLine("Enter the number of rows of matrix B");
                var stringRowsB = Console.ReadLine();
                if (!int.TryParse(stringRowsB, out var rowsB) || rowsB <= 0)
                {
                    PrintErrorIncorrectData();
                    continue;
                }

                Console.WriteLine("Enter the number of columns of matrix B");
                var stringColumnsB = Console.ReadLine();
                if (!int.TryParse(stringColumnsB, out var columnsB) || columnsB <= 0)
                {
                    PrintErrorIncorrectData();
                    continue;
                }


                var matrixA = new Core.Matrix(rowsA, columnsA);
                var matrixB = new Core.Matrix(rowsB, columnsB);

                Console.WriteLine("Enter the data of the matrix A");
                FillMatrix(matrixA);
                Console.WriteLine("Enter the data of the matrix B");
                FillMatrix(matrixB);

                Console.WriteLine("Matrix A \n" + matrixA);
                Console.WriteLine("Matrix B \n" + matrixB);

                Console.WriteLine("Select action on matrices: " +
                                  "\n1.Addition" +
                                  "\n2.Subtraction" +
                                  "\n3.Multiplication");

                var chooseAction = Console.ReadLine();

                try
                {
                    switch (chooseAction)
                    {
                        case "1":
                            Console.WriteLine("Matrix A + B \n" + (matrixA + matrixB));
                            break;
                        case "2":
                            Console.WriteLine("Matrix A - B \n" + (matrixA - matrixB));
                            break;
                        case "3":
                            Console.WriteLine("Matrix A * B \n" + (matrixA * matrixB));
                            break;
                        default:
                            PrintErrorIncorrectData();
                            break;
                    }
                }

                catch (MatrixDimensionsIncorrectException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message + "\n" + ex.InformationDimension);
                }
            }
        }

        /// <summary>
        /// Заполняет матрицу значениями, которые будут введены с клавиатуры
        /// </summary>
        /// <param name="matrix">Матрица, которую следует заполнить значениями</param>
        public static void FillMatrix(Core.Matrix matrix)
        {
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {

                    while (true)
                    {
                        Console.Write("[" + i + "]" + "[" + j + "] ");

                        var stringElementMatrix = Console.ReadLine();

                        if (!double.TryParse(stringElementMatrix, out var elementMatrix))
                        {
                            PrintErrorIncorrectData();
                            continue; // Повторить ввод значения, пока не будет введено корректное значение элемента матрицы
                        }

                        matrix[i, j] = elementMatrix;
                        break; // Если значение введено корректно, переходим к вводу следующего значения элемента матрицы
                    }

                }
            }
        }

        private static void PrintErrorIncorrectData()
        {
            Console.WriteLine("Incorrect entered data (e.g incorrect characters, words)");
        }
    }
}
