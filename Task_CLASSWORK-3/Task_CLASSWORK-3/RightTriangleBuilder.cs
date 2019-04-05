using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of TriangleBuilder, Builds right triangle (Triangle has right angle).
    /// </summary>
    public class RightTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor of RightTriangleBuilder.
        /// </summary>
        /// <param name="triangleBuilder">Reference to next builder</param>
        public RightTriangleBuilder(TriangleBuilder triangleBuilder) : base(triangleBuilder) { }

        /// <summary>
        /// Override method builds right triangle.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        /// <returns></returns>
        public override Triangle Build(Point one, Point two, Point three)
        {
            OneLine = one.GetDistance(two);
            TwoLine = one.GetDistance(three);
            ThreeLine = two.GetDistance(three);

            // The conditions of right triangle.
            if (IsTriangle() && IsRightTriangle())
            {
                return new RightTriangle(one, two, three);
            }

            return Successor?.Build(one, two, three);
        }

        /// <summary>
        /// Method defines that figure is right triangle.
        /// </summary>
        /// <returns></returns>
        public bool IsRightTriangle() => ((Math.Abs(Math.Pow(OneLine, 2) + Math.Pow(TwoLine, 2) - Math.Pow(ThreeLine, 2)) < exp || Math.Abs(Math.Pow(OneLine, 2) + Math.Pow(ThreeLine, 2) - Math.Pow(TwoLine, 2)) < exp || Math.Abs(Math.Pow(TwoLine, 2) + Math.Pow(ThreeLine, 2) - Math.Pow(OneLine, 2)) < exp));
    }
}
