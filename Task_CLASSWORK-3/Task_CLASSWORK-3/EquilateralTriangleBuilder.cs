using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of TriangleBuilder, Builds equilateral triangle (Triangle have three equal sides).
    /// </summary>
    public class EquilateralTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor of EquilateralTriangleBuilder.
        /// </summary>
        /// <param name="triangleBuilder">Reference to next builder</param>
        public EquilateralTriangleBuilder(TriangleBuilder triangleBuilder) : base(triangleBuilder) { }

        /// <summary>
        /// Override methods build equilateral triangle.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        /// <returns>Object of Triangle</returns>
        public override Triangle Build(Point one, Point two, Point three)
        {
            OneLine = one.GetDistance(two);
            TwoLine = one.GetDistance(three);
            ThreeLine = two.GetDistance(three);
            
            // The conditions of equilateral triangle.
            if (IsTriangle() && IsEquilateralTriangle())
            {
                return new EquilateralTriangle(one, two, three);
            }

            return Successor?.Build(one, two, three);
        }

        /// <summary>
        /// Method defines that figure is equilateral triangle.
        /// </summary>
        /// <returns></returns>
        public bool IsEquilateralTriangle() => (Math.Abs(OneLine - TwoLine) < exp && Math.Abs(TwoLine - ThreeLine) < exp);
    }
}
