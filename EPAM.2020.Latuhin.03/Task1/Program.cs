using System;

namespace RootFind.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter the number to find the root");
                var inputStringNumber = Console.ReadLine();
                if (!double.TryParse(inputStringNumber, out var number))
                {
                    PrintError();
                    continue;
                }

                Console.WriteLine("Enter the degree of finding the root");
                var inputStringDegree = Console.ReadLine();
                if (!int.TryParse(inputStringDegree, out var degree))
                {
                    PrintError();
                    continue;
                }

                Console.WriteLine("Enter the precision of finding the root");
                var inputStringPrecision = Console.ReadLine();
                if (!double.TryParse(inputStringPrecision, out var precision))
                {
                    PrintError();
                    continue;
                }

                try
                {
                    var resultNewton = RootFinder.Newton(number, degree, precision);
                    Console.WriteLine("Result using Newton's method: " + resultNewton);
                    Console.WriteLine("Result using method Math.Pow: " + Math.Pow(number, 1.0 / degree));

                    var resultCompare = RootFinder.CompareNewtonToPow(resultNewton, number, degree);
                    if (resultCompare == 0)
                    {
                        Console.WriteLine("The results of Math.Pow method and Newton's method is the same");
                    }
                    else
                    {
                        Console.WriteLine($"Difference of Math.Pow method from Newton's method: {resultCompare}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintError()
        {
            Console.WriteLine("Please, check the correctness of the entered data");
        }
    }
}
