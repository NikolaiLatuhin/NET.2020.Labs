using System;

namespace RootFind.Core
{
    /// <summary>
    /// Класс позволяет находит корень n степени методом Ньютона
    /// И сравнивать результат полученный с помощью Math.Pow
    /// </summary>
    public static class RootFinder
    {
        /// <summary>
        /// Функция позволяет вычислить корень n степени методом Ньютона
        /// </summary>
        /// <param name="number">Исходное число, корень которого надо найти</param>
        /// <param name="degree">Степень нахождения корня</param>
        /// <param name="precision">Точность вычисления</param>
        /// <returns>Возвращает корень n-ой степени</returns>
        public static double Newton(double number, int degree, double precision)
        {
            if ((number) < 0 | (degree < 1) | (precision <= 0))
                throw new Exception("An error occurred when entering a number, degree of root, or precision");
            if (number == 0)
                return 0;

            // Начальное предположение.
            const int InitialGuess = 1; 
            double resultNewton = InitialGuess;
            double x;
            do
            {
                x = resultNewton;
                // Используется формула Ньютона.
                resultNewton = ((degree - 1) * x + number / Math.Pow(x, degree - 1)) / degree;
                // Выполняем цикл, пока не будет достигнута необходимая точность.
            } while (Math.Abs(x - resultNewton) > precision);
            return resultNewton;
        }

        /// <summary>
        /// Сравнение результатов работы нахождения корня n-степени методом Ньютона 
        /// и с помощью метода Math.Pow 
        /// </summary>
        /// <param name="resultNewtonMethod">Результат полученный при вычислении корня методом Ньютона</param>
        /// <param name="number">Число, корень корого следует вычислить</param>
        /// <param name="precision">Степень корня</param>
        /// <returns>Возвращает разницу между значениями корня полученного с помощью Math.Pow и методом Ньютона. Возвращает 0 в случае равенства</returns>
        public static double CompareNewtonToPow(double resultNewtonMethod, double number, int precision)
        {
            double powNumber = Math.Pow(number, 1.0 / precision);

            if (powNumber < resultNewtonMethod)
            {
                return powNumber - resultNewtonMethod;
            }
            else if (powNumber > resultNewtonMethod)
            {
                return powNumber - resultNewtonMethod;
            }
            return 0;
        }
    }
}
