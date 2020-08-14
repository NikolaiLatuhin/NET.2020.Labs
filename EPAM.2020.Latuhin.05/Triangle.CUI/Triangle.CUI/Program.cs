using System;
using Triangle.Core;

namespace Triangle.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, this program can calculate triangle perimeter and area");

            while (true)
            {
                Console.WriteLine("Enter the side A, which value greater than zero");
                var stringSideA = Console.ReadLine();
                double.TryParse(stringSideA, out var sideA);

                Console.WriteLine("Enter the side B, which value greater than zero");
                var stringSideB = Console.ReadLine();
                double.TryParse(stringSideB, out var sideB);

                Console.WriteLine("Enter the side C, which value greater than zero");
                var stringSideC = Console.ReadLine();
                double.TryParse(stringSideC, out var sideC);

                try
                {
                    var triangle = Triangles.CreateTriangle(sideA, sideB, sideC);
                    var perimeter = triangle.FindPerimeter();
                    var area = triangle.FindArea();

                    Console.WriteLine($"Perimeter this triangle {perimeter}");
                    Console.WriteLine($"Area this triangle {area}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
