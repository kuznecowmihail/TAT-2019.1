namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of TriangleBuilder, Builds regular triangle.
    /// </summary>
    class RegularTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor of RegularTriangleBuilder.
        /// </summary>
        /// <param name="triangleBuilder">Reference to nesxt builder</param>
        public RegularTriangleBuilder(TriangleBuilder triangleBuilder) : base(triangleBuilder) { }

        /// <summary>
        /// Override method builds regular triangle.
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

            // The conditions of regular triangle.
            if (IsTriangle())
            {
                return new RegularTriangle(one, two, three);
            }

            return Successor?.Build(one, two, three);
        }
    }
}
