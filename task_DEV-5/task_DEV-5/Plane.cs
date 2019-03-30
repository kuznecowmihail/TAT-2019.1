namespace task_DEV_5
{
    /// <summary>
    /// Child class is Plane.
    /// </summary>
    public class Plane : FlyingObject
    {
        double StartSpeed { get; }
        double Acceleration { get; }
        double DistanceOfChangeSpeed { get; }

        /// <summary>
        /// Constructor of Plane.
        /// </summary>
        public Plane(double speed = 200, double acceleration = 10, double distanceOfChargeSpeed = 10) : base(speed)
        {
            StartSpeed = speed;
            // Every 10 km speed +10 km/h.
            Acceleration = acceleration;
            DistanceOfChangeSpeed = distanceOfChargeSpeed;
        }

        public override void FlyTo(Point newPoint)
        {
            base.FlyTo(newPoint);
            Speed = StartSpeed;
        }

        /// <summary>
        /// Override method of base class.
        /// </summary>
        /// <returns>Time of flight</returns>
        public override double GetFlyTime()
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
