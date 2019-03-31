namespace task_DEV_5
{
    /// <summary>
    /// Child class is Plane.
    /// </summary>
    public class Plane : FlyingObject
    {
        static double StartSpeed { get; } = 200;
        // Every 10 km speed +10 km/h.
        static double Acceleration { get; } = 10;
        static double DistanceOfChangeSpeed { get; } = 10;

        /// <summary>
        /// Constructor of Plane.
        /// </summary>
        public Plane() : base(StartSpeed) { }

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
            while(distance > 0)
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
