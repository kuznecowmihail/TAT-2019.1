﻿using System;

namespace task_DEV_5
{
    /// <summary>
    /// Struct of point.
    /// </summary>
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        /// <summary>
        /// Constructor of point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Method calculates distance beetwen two points.
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        public double GetDistance(Point otherPoint)
        {
            return Math.Sqrt(Math.Pow(otherPoint.X - X, 2) + Math.Pow(otherPoint.Y - Y, 2) + Math.Pow(otherPoint.Z - Z, 2));
        }
    }
}
