using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Struct point, that has two coordinates.
    /// </summary>
    public struct Point
    {
        public double X { get; }
        public double Y { get; }

        /// <summary>
        /// Constructor of Point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Method returns distance between two points.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public double GetDistance(Point point) => Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}
