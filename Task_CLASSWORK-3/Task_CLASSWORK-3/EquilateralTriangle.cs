using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of triangle, one of the type of triangle (Triangle have three equal sides).
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Constructor of EquillateralTriangle.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        public EquilateralTriangle(Point one, Point two, Point three) : base(one, two, three) { }

        /// <summary>
        /// Override method return square of triangle.
        /// </summary>
        /// <returns>Square</returns>
        public override double GetSquare() => Math.Pow(One.GetDistance(Two), 2) * Math.Sqrt(3) / 4;
    }
}
