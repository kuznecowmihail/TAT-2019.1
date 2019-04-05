namespace Task_CLASSWORK_3
{
    /// <summary>
    /// Child class of triangle, one of the type of triangle.
    /// </summary>
    class RegularTriangle : Triangle
    {
        /// <summary>
        /// Constructor of EquillateralTriangle.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        public RegularTriangle(Point one, Point two, Point three) : base(one, two, three) { }
    }
}
