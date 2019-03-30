namespace task_DEV_5
{
    /// <summary>
    /// Child class is Plane.
    /// </summary>
    public class Plane : FlyingObject, IFlyable
    {
        double Acceleration { get; }
        double DistanceOfChangeSpeed { get; }
        public event AccountStateHandler ObjectFliesToPoint;

        /// <summary>
        /// Constructor of Plane.
        /// </summary>
        public Plane(double acceleration = 10, double distanceOfChargeSpeed = 10, double speed = 200) : base()
        {
            // Every 10 km speed +10 km/h.
            Acceleration = acceleration;
            DistanceOfChangeSpeed = distanceOfChargeSpeed;
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
            double distance = StartPoint.GetDistance(FinishPoint);
            double time = 0;
            for (int i = 0; i <= distance / Acceleration; i++)
            {
                if (distance < DistanceOfChangeSpeed)
                {
                    time += distance / Speed;
                    break;
                }
                time += DistanceOfChangeSpeed / Speed;
                Speed += Acceleration;
                distance -= DistanceOfChangeSpeed;
            }
            return time;
        }
    }
}
