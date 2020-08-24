using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Core;

namespace Matrix.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows of matrix A");
            var userRowsA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns of matrix A");
            var userColumnA = Convert.ToInt32(Console.ReadLine());
            var matrix1 = new Core.Matrix(userRowsA, userColumnA);

            Console.WriteLine("Enter the number of rows of matrix B");
            var userRowsB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns of matrix B");
            var userColumnB = Convert.ToInt32(Console.ReadLine());

            var matrix2 = new Core.Matrix(userRowsB, userColumnB);


            Console.WriteLine("Enter the data of the matrix A");
            var dataMatrix1 = FillArray(userRowsA, userColumnA);
            matrix1.FillMatrix(dataMatrix1);
            Console.WriteLine("Enter the data of the matrix B");
            var dataMatrix2 = FillArray(userRowsB, userColumnB);
            matrix2.FillMatrix(dataMatrix2);


            Console.WriteLine("Matrix 1 \n" + matrix1);
            Console.WriteLine("Matrix 2 \n" + matrix2);


            Console.WriteLine("Select action on matrices: " +
                "\n1.Addition" +
                "\n2.Subtraction" +
                "\n3.Multiplication");
            var chooseAction = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (chooseAction)
                {
                    case 1:
                        Console.WriteLine("Matrix A + B \n" + (matrix1 + matrix2));
                        break;
                    case 2:
                        Console.WriteLine("Matrix A - B \n" + (matrix1 - matrix2));
                        break;
                    case 3:
                        Console.WriteLine("Matrix A * B \n" + (matrix1 * matrix2));
                        break;
                }
            }

            catch (MatrixDimensionsIncorrectException ex)
            {
                Console.WriteLine("Exception: " + ex.Message + "\n" + ex.InformationDimension);
            }
        }

        public static double[,] FillArray(int x, int y)
        {
            var input = new double[x, y];
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    Console.Write("[" + i + "]" + "[" + j + "] ");
                    input[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return input;
        }
    }
}
