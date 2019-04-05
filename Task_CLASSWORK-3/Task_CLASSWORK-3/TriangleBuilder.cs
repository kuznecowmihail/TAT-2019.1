namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Base class is builder of triangle.
    /// </summary>
    public abstract class TriangleBuilder
    {
        protected double OneLine { get; set; }
        protected double TwoLine { get; set; }
        protected double ThreeLine { get; set; }
        public TriangleBuilder Successor { get; }
        protected const double e = 0.01;

        /// <summary>
        /// Constructor of TriangleBuilder.
        /// </summary>
        /// <param name="triangleBuilder">Reference to next builder</param>
        public TriangleBuilder(TriangleBuilder triangleBuilder)
        {
            Successor = triangleBuilder;
        }

        /// <summary>
        /// Abstract method takes three points and build triangle if conditions are met.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        /// <returns></returns>
        public abstract Triangle Build(Point one, Point two, Point three);

        /// <summary>
        /// Method defines that figure is triangle.
        /// </summary>
        /// <returns></returns>
        public bool IsTriangle() => (OneLine < TwoLine + ThreeLine && TwoLine < OneLine + ThreeLine && ThreeLine < OneLine + TwoLine);
    }
}
