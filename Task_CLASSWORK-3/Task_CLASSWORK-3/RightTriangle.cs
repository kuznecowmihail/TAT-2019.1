using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of triangle, one of the type of triangle.
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// Constructor of EquillateralTriangle.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        public RightTriangle(Point one, Point two, Point three) : base(one, two, three) { }

        /// <summary>
        /// Override method return square of triangle.
        /// </summary>
        /// <returns>Square</returns>
        public override double GetSquare()
        {
            double[] lines = new double[] { OneLine, TwoLine, ThreeLine };
            // Sort lines in ascerding order for select  two smaller sides (two rolls of triangle).
            Array.Sort(lines);
            double square = 0.5;

            for(int i = 0; i < lines.Length - 1; i++)
            {
                square *= lines[i];
            }

            return square;
        }
    }
}
