namespace task_DEV_5
{
    /// <summary>
    /// Child class is SpaceShip.
    /// </summary>
    public class SpaceShip : FlyingObject
    {
        const double startPoint = 28.8E+6;

        /// <summary>
        /// Constructor of SpaceShip.
        /// </summary>
        public SpaceShip() : base(startPoint) { }
    }
}
