using System;

namespace task_DEV_5
{
    /// <summary>
    /// Child class is Bird.
    /// </summary>
    public class Bird : FlyingObject, IFlyable
    {
        public event AccountStateHandler ObjectFliesToPoint;

        /// <summary>
        /// Constuctor of Bird, initializes random speed 1-20 km/h.
        /// </summary>
        public Bird() : base()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            Speed = random.Next(1, 20);
        }

        /// <summary>
        /// Method of flight to newPoint.
        /// </summary>
        /// <param name="newPoint"></param>
        public void FlyTo(Point newPoint)
        {
            FinishPoint = newPoint;
            ObjectFliesToPoint?.Invoke(WhoAmI(), new FlyingObjectEventArgs(StartPoint.GetDistance(FinishPoint), GetFlyTime(), Speed, StartPoint, FinishPoint));
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
