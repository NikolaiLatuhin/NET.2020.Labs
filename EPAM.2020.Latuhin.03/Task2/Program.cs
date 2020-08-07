using System;

namespace BinaryConvert.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a non-negative decimal integer value to convert to binary");
                // Строка, для хранения неотрицательного десятичного целого числа .
                var numberDecimal = Console.ReadLine();
                // Проверка на корректность введенных числовых значений.
                if (UInt32.TryParse(numberDecimal, out var number))
                {
                    Console.WriteLine("Converting with a standard class: " + BinaryConverter.ToBinaryWithStandardСlass(number));
                    Console.WriteLine("Converting with a created  class: " + BinaryConverter.ToBinaryWithAlgorithm(number));
                }
                else
                {
                    Console.WriteLine("Please, check the correctness of the entered data");
                }
            }
        }
    }
}
