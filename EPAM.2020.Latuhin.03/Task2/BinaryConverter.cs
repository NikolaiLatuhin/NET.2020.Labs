using System;
using System.Text;

namespace BinaryConvert.Core
{
    /// <summary>
    /// Класс позволяет переводить неотрицательное число из десятичной системы исчисления в двоичную
    /// Используя либо стандартные методы конвертирования либо собственный алгоритм
    /// </summary>
    public static class BinaryConverter
    {
        /// <summary>
        /// Перевод числа в двоичную систему исчисления с использованием алгоритма
        /// </summary>
        /// <param name="number">Число, которое будет преобразовано в двоичную систему исчисления</param>
        /// <returns>Возвращает строку, содержащую двоичное представление числа</returns>
        public static string ToBinaryWithAlgorithm(uint number)
        {
            StringBuilder result = new StringBuilder();

            if (number == 0)
                return "0";

            while (number > 0)
            {
                uint digit = number % 2;
                result.Insert(0, digit);
                number /= 2;
            }

            return result.ToString();
        }

        /// <summary>
        /// Перевод числа в двоичную систему исчисления с использованием стандартного класса
        /// </summary>
        /// <param name="number">Число, которое будет преобразовано в двоичную систему исчисления</param>
        /// <returns>Возвращает строку, содержащую двоичное представление числа</returns>
        public static string ToBinaryWithStandardСlass(uint number)
        {
            return Convert.ToString(number, 2);
        }
    }
}
