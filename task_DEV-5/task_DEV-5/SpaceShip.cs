namespace task_DEV_5
{
    /// <summary>
    /// Child class is SpaceShip.
    /// </summary>
    public class SpaceShip : FlyingObject, IFlyable
    {
        public event AccountStateHandler ObjectFliesToPoint;

        /// <summary>
        /// Constructor of SpaceShip.
        /// </summary>
        public SpaceShip(double speed = 28.8E+6) : base()
        {
            Speed = speed;
        }

        /// <summary>
        /// Implemented interface method.
        /// </summary>
        /// <param name="newPoint"></param>
        public void FlyTo(Point newPoint)
        {
            FinishPoint = newPoint;
            ObjectFliesToPoint?.Invoke(WhoAmI(), new FlyingObjectEventArgs(StartPoint.GetDistance(FinishPoint), GetFlyTime(), Speed, StartPoint, newPoint));
            StartPoint = newPoint;
        }

        /// <summary>
        /// Implemented interface method.
        /// </summary>
        /// <returns this></returns>
        public IFlyable WhoAmI()
        {
            return this;
        }

        /// <summary>
        /// Implemented interface method.
        /// </summary>
        /// <returns>Time of flight</returns>
        public double GetFlyTime()
        {
            return StartPoint.GetDistance(FinishPoint) / Speed;
        }
    }
}
