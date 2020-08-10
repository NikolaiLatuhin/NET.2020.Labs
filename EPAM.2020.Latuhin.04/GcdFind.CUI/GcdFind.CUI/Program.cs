using System;
using GcdFind.Core;

namespace GcdFind.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Please, enter amount of numbers to search for GCD");
                var stringAmount = Console.ReadLine();

                if (!uint.TryParse(stringAmount, out var amountNumbers) | (amountNumbers <= 1))
                {
                    Console.WriteLine("Check the correctness of the entered amount of numbers");
                    // Повторяем ввод пока не будет введено корректное значение
                    continue;
                }

                var numbers = new int[amountNumbers];
                for (var i = 0; i < amountNumbers; i++)
                {
                    while (true)
                    {
                        Console.WriteLine($"Enter the number[{i + 1}] of {amountNumbers} numbers");
                        var stringNumber = Console.ReadLine();

                        if (!int.TryParse(stringNumber, out var number))
                        {
                            Console.WriteLine("Please, check the correctness of the entered number");
                            // Повторяем ввод пока не будет введено корректное значение
                            continue;
                        }
                        numbers[i] = number;
                        break;
                    }
                }

                try
                {
                    var gcdEuclidean = GcdFinder.FindWithEuclidean(out var elapsedTimeEuclidean, numbers);
                    var gcdStein = GcdFinder.FindWithStein(out var elapsedTimeStein, numbers);

                    Console.WriteLine($"GCD for entered numbers with Euclidean algorithm is {gcdEuclidean}. " +
                                      $"Elapsed time {elapsedTimeEuclidean.TotalMilliseconds} milliseconds");

                    Console.WriteLine($"GCD for entered numbers with Stein algorithm is {gcdStein}. " +
                                      $"Elapsed time {elapsedTimeStein.TotalMilliseconds} milliseconds");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
