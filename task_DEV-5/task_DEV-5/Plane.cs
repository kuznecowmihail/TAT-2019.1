namespace task_DEV_5
{
    /// <summary>
    /// Child class is Plane.
    /// </summary>
    public class Plane : FlyingObject
    {
        const double startSpeed = 200;
        // Every 10 km speed +10 km/h.
        const double acceleration = 10;
        const double distanceOfChangeSpeed = 10;

        /// <summary>
        /// Constructor of Plane.
        /// </summary>
        public Plane() : base(startSpeed) { }

        public override void FlyTo(Point newPoint)
        {
            base.FlyTo(newPoint);
            Speed = startSpeed;
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
                if (distance < distanceOfChangeSpeed)
                {
                    time += distance / Speed;
                    break;
                }
                time += distanceOfChangeSpeed / Speed;
                Speed += acceleration;
                distance -= distanceOfChangeSpeed;
            }
            return time;
        }
    }
}
