namespace task_DEV_5
{
    /// <summary>
    /// Base abstract class of flying objects.
    /// </summary>
    public abstract class FlyingObject : IFlyable
    {
        public event AccountStateHandler ObjectFliesToPoint;
        protected double Speed { get; set; }
        protected Point StartPoint { get; set; }
        protected Point FinishPoint { get; set; }

        /// <summary>
        /// Constuctor of FlyingObject.
        /// </summary>
        public FlyingObject(double speed)
        {
            Speed = speed;
        }

        /// <summary>
        /// Implemented interface method.
        /// </summary>
        /// <param name="newPoint"></param>
        virtual public void FlyTo(Point newPoint)
        {
            FinishPoint = newPoint;
            ObjectFliesToPoint?.Invoke(WhoAmI(), new FlyingObjectEventArgs(StartPoint, FinishPoint, StartPoint.GetDistance(FinishPoint), GetFlyTime(), Speed));
            StartPoint = FinishPoint;
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
        virtual public double GetFlyTime()
        {
            return StartPoint.GetDistance(FinishPoint) / Speed;
        }
    }
}
