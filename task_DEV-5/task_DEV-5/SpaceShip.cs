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
        /// Method of flight to newPoint.
        /// </summary>
        /// <param name="newPoint"></param>
        public void FlyTo(Point newPoint)
        {
            FinishPoint = newPoint;
            ObjectFliesToPoint?.Invoke(WhoAmI(), new FlyingObjectEventArgs(StartPoint.GetDistance(FinishPoint), GetFlyTime(), Speed, StartPoint, newPoint));
            StartPoint = newPoint;
        }

        /// <summary>
        /// Method returns a reference of this object.
        /// </summary>
        /// <returns this></returns>
        public IFlyable WhoAmI()
        {
            return this;
        }

        /// <summary>
        /// Method calculates time of flight.
        /// </summary>
        /// <returns>Time of flight</returns>
        public double GetFlyTime()
        {
            return StartPoint.GetDistance(FinishPoint) / Speed;
        }
    }
}
