using System;

namespace Triangle.Core
{
    /// <summary>
    /// Класс позволяет создавать треугольник со сторонами.
    /// А также находить периметр и площадь треугольника
    /// </summary>
    public class Triangles
    {
        private double SideA { get; set; }
        private double SideB { get; set; }
        private double SideC { get; set; }

        /// <summary>
        /// Функция для поиска периметра
        /// </summary>
        /// <returns>Возвращает значение периметра</returns>
        public double FindPerimeter()
        {
            return SideA + SideB + SideC;
        }

        /// <summary>
        /// Функция для поиска площади по формуле Герона
        /// </summary>
        /// <returns>Возвращает значение площади</returns>
        public double FindArea()
        {
            var halfPerimeter = (SideA + SideB + SideC) / 2.0; // Полупериметр.
            var area = Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC)); // Формула Герона.
            return area;
        }

        /// <summary>
        /// Функция для проверки корректности введенных сторон
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <returns>Возвращает true, если значение сторон корректно</returns>
        public static bool CheckSides(double sideA, double sideB, double sideC)
        {
            return sideA > 0 & sideB > 0 & sideC > 0;
        }

        /// <summary>
        /// Функция для проверки существования треугольника с заданными сторонами
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <returns>Возвращает true, если треугольник существует</returns>
        public static bool CheckExisting(double sideA, double sideB, double sideC)
        {
            return sideA + sideB > sideC & sideA + sideC > sideB & sideB + sideC > sideA;
        }

        /// <summary>
        /// Функция позволяет создать треугольник с заданными сторонами
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <returns>Возвращает объект типа Triangles с заданными сторонами</returns>
        public static Triangles CreateTriangle(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangles();
            if(!CheckSides(sideA, sideB, sideC))
                throw new ArgumentException("Side must be greater than zero or incorrect data");
            if(!CheckExisting(sideA, sideB, sideC))
                throw new ArgumentException("Triangle with this sides cannot be exist");
            triangle.SideA = sideA;
            triangle.SideB = sideB;
            triangle.SideC = sideC;

            return triangle;
        }

        private Triangles() { }
    }
}
