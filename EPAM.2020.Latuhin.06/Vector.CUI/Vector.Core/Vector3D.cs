namespace Vector.Core
{
    /// <summary>
    /// Класс позволяет работать с векторами в трехмерном пространстве
    /// </summary>
    public class Vector3D
    {
        private double X { get; set; }
        private double Y { get; set; }
        private double Z { get; set; }

        public Vector3D() { }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Сложение векторов
        /// </summary>
        /// <param name="vector1">Вектор 1</param>
        /// <param name="vector2">Вектор 2</param>
        /// <returns>Возвращает новый вектор a+b</returns>
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            var resultVector = new Vector3D
            {
                X = vector1.X + vector2.X,
                Y = vector1.Y + vector2.Y,
                Z = vector1.Z + vector2.Z
            };

            return resultVector;
        }

        /// <summary>
        /// Вычитание векторов
        /// </summary>
        /// <param name="vector1">Вектор 1</param>
        /// <param name="vector2">Вектор 2</param>
        /// <returns>Возвращает новый вектор a-b</returns>
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            var v = new Vector3D
            {
                X = vector1.X - vector2.X,
                Y = vector1.Y - vector2.Y,
                Z = vector1.Z - vector2.Z
            };

            return v;
        }

        /// <summary>
        /// Векторное умножение
        /// </summary>
        /// <param name="vector1">Вектор 1</param>
        /// <param name="vector2">Вектор 2</param>
        /// <returns>Возвращает векторное произведение</returns>
        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            var v = new Vector3D
            {
                X = vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                Y = vector1.Z * vector2.X - vector1.X * vector2.Z,
                Z = vector1.X * vector2.Y - vector1.Y * vector2.X
            };

            return v;
        }

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="vector1">Вектор 1</param>
        /// <param name="vector2">Вектор 2</param>
        /// <returns>Возваращает скалярное произведение</returns>
        public static double operator %(Vector3D vector1, Vector3D vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Vector3D))
                return false;

            return (X == ((Vector3D)obj).X) 
                   && (Y == ((Vector3D)obj).Y) 
                   && (Z == ((Vector3D)obj).Z);
        }

        /// <summary>
        /// Переопределяет метод для формирования строкого представления
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return X + ":" + Y + ":" + Z + "";
        }
    }
}
