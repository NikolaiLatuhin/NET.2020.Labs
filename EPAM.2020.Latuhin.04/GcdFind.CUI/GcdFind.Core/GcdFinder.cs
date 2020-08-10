using System;
using System.Diagnostics;

namespace GcdFind.Core
{
    /// <summary>
    /// Класс позволяет находить НОД с использованием алгоритма Евклида и алгоритма Стейна
    /// Позволяет замерять время выполнения данных алгоритмов
    /// </summary>
    public class GcdFinder
    {
        /// <summary>
        /// Функция для нахождения НОД двух чисел с использованием алгоритма Ньютона
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Возвращает НОД введенных чисел</returns>
        public static int FindWithEuclidean(int a, int b)
        {
            if ((a == 0) & (b == 0))
            {
                throw new Exception("The value of two pair numbers cannot be zero");
            }

            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return Math.Abs(a); // Берем число по модулю, для предотвращение отрицательного НОД
        }

        /// <summary>
        /// Функция для нахождения НОД нескольких чисел с использованием алгоритма Ньютона
        /// </summary>
        /// <param name="numbers">Числа для которых будет найден НОД</param>
        /// <returns>Возвращает НОД введенных чисел</returns>
        public static int FindWithEuclidean(params int[] numbers)
        {
            var result = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                result = FindWithEuclidean(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Функция для нахождения НОД двух чисел с использованием алгоритма Стейна
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Возвращает НОД введенных чисел</returns>
        public static int FindWithStein(int a, int b) // Изменить название метода
        {
            if ((a == 0) & (b == 0))
            {
                throw new Exception("The value of all numbers cannot be zero");
            }

            // Берем числа по модулю, для предотвращения отрицательного НОД
            a = Math.Abs(a); 
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            switch (a)
            {
                case 0:
                    return b;
                case 1:
                    return 1;
            }

            switch (b)
            {
                case 0:
                    return a;
                case 1:
                    return 1;
            }

            if ((a % 2 == 0) & (b % 2 == 0))
            {
                return 2 * FindWithStein(a / 2, b / 2);
            }

            if ((a % 2 == 0) & (b % 2 != 0))
            {
                return FindWithStein(a / 2, b);
            }

            if ((a % 2 != 0) & (b % 2 == 0))
            {
                return FindWithStein(a, b / 2);
            }

            if ((a % 2 != 0) & (b % 2 != 0) & (b > a))
            {
                return FindWithStein((b - a / 2), a);
            }

            if ((a % 2 != 0) & (b % 2 != 0) & (b < a))
            {
                return FindWithStein((a - b / 2), b);
            }
            return -1;
        }

        /// <summary>
        /// Функция для нахождения НОД нескольких чисел с использованием алгоритма Стейна
        /// </summary>
        /// <param name="numbers">Числа для которых будет найден НОД</param>
        /// <returns>Возвращает НОД введенных чисел</returns>
        public static int FindWithStein(params int[] numbers)
        {
            var result = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                result = FindWithStein(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Метод-обертка для замера времени выполнения алгоритма Стейна
        /// </summary>
        /// <param name="elapsedTime">Время выполнения алгоритма</param>
        /// <param name="numbers">Числа для которых будет найден НОД</param>
        /// <returns>Возврщает НОД введенных чисел</returns>
        public static int FindWithStein(out TimeSpan elapsedTime, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = FindWithStein(numbers);
            stopWatch.Stop();

            elapsedTime = stopWatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Метод-обертка для замера времени выполнения алгоритма Евклида
        /// </summary>
        /// <param name="elapsedTime">Время выполнения алгоритма</param>
        /// <param name="numbers">Числа для которых будет найден НОД</param>
        /// <returns>Возврщает НОД введенных чисел</returns>
        public static int FindWithEuclidean(out TimeSpan elapsedTime, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = FindWithEuclidean(numbers);
            stopWatch.Stop();

            elapsedTime = stopWatch.Elapsed;

            return result;
        }
    }
}