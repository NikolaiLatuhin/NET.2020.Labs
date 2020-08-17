using System;
using Vector.Core;

namespace Vector.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("The program allows you to perform on vectors: add, subtract, cross and scalar product");
                Console.WriteLine("Now you will enter the coordinates of the vector A (x,y,z)");
                FillVector1(out var x1, out var y1, out var z1);
                Console.WriteLine("Now you will enter the coordinates of the vector B (x,y,z)");
                FillVector2(out var x2, out var y2, out var z2);

                var vector1 = new Vector3D(x1, y1, z1);
                Console.WriteLine($"Vector A has coordinates {vector1}");
                var vector2 = new Vector3D(x2, y2, z2);
                Console.WriteLine($"Vector B has coordinates {vector2}");
                Vector3D resultVector;

                Console.WriteLine("Select action for two vectors" +
                                  "\n1. Addition" +
                                  "\n2. Subtraction" +
                                  "\n3. Cross product" +
                                  "\n4. Scalar product");


                var stringChoose = Console.ReadLine();
                if (!int.TryParse(stringChoose, out var choose) | choose <= 0 | choose > 5)
                {
                    Console.WriteLine("Incorrect data input");
                    continue;
                }

                switch (choose)
                {
                    case 1:
                        resultVector = vector1 + vector2;
                        Console.WriteLine($"The result of adding vectors a + b is vector c {resultVector}");
                        break;
                    case 2:
                        resultVector = vector1 - vector2;
                        Console.WriteLine($"The result of subtracting vectors a - b is vector c {resultVector}");
                        break;
                    case 3:
                        resultVector = vector1 * vector2;
                        Console.WriteLine($"The result of the cross product a x b is a vector c {resultVector}");
                        break;
                    case 4:
                        Console.WriteLine($"Scalar product of vectors a * b  = {vector1 % vector2}");
                        break;
                }
            }
        }

        private static void FillVector1(out double coordinateX1, out double coordinateY1, out double coordinateZ1)
        {
            Console.WriteLine("Enter the coordinate x, which value greater than zero");
            var stringCoordinateX = Console.ReadLine();
            double.TryParse(stringCoordinateX, out coordinateX1);

            Console.WriteLine("Enter the coordinate y, which value greater than zero");
            var stringCoordinateY = Console.ReadLine();
            double.TryParse(stringCoordinateY, out coordinateY1);

            Console.WriteLine("Enter the coordinate z, which value greater than zero");
            var stringCoordinateZ = Console.ReadLine();
            double.TryParse(stringCoordinateZ, out coordinateZ1);
        }

        private static void FillVector2(out double coordinateX2, out double coordinateY2, out double coordinateZ2)
        {
            Console.WriteLine("Enter the coordinate x, which value greater than zero");
            var stringCoordinateX = Console.ReadLine();
            double.TryParse(stringCoordinateX, out coordinateX2);

            Console.WriteLine("Enter the coordinate y, which value greater than zero");
            var stringCoordinateY = Console.ReadLine();
            double.TryParse(stringCoordinateY, out coordinateY2);

            Console.WriteLine("Enter the coordinate z, which value greater than zero");
            var stringCoordinateZ = Console.ReadLine();
            double.TryParse(stringCoordinateZ, out coordinateZ2);
        }
    }
}
