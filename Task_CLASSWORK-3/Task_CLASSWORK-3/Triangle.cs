using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Base class.
    /// </summary>
    public class Triangle
    {
        protected Point One { get; }
        protected Point Two { get; }
        protected Point Three { get; }
        protected double OneLine { get; }
        protected double TwoLine { get; }
        protected double ThreeLine { get; }
        protected const double exp = 0.01;

        /// <summary>
        /// Constructor of Triangle
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        public Triangle(Point one, Point two, Point three)
        {
            One = one;
            Two = two;
            Three = three;
            OneLine = One.GetDistance(Two);
            TwoLine = One.GetDistance(Three);
            ThreeLine = Two.GetDistance(Three);
        }

        /// <summary>
        /// Vitrual method returns square of triangle.
        /// </summary>
        /// <returns>Square</returns>
        virtual public double GetSquare()
        {
            // Theorem of cosinus.
            double sinus = Math.Sqrt(1 - (Math.Pow(ThreeLine, 2) - Math.Pow(OneLine, 2) - Math.Pow(TwoLine, 2))/(2 * OneLine * TwoLine));

            return (0.5 * OneLine * TwoLine * sinus);
        }
    }
}
