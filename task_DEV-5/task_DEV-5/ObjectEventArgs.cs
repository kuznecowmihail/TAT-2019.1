namespace task_DEV_5
{
    /// <summary>
    /// Class for an event that has some information.
    /// </summary>
    public class FlyingObjectEventArgs
    {
        public double Distance { get; }
        public double Time { get; }
        public double Speed { get; }
        public Point StartPoint { get; }
        public Point FinishPoint { get; }

        /// <summary>
        /// Constructor of FlyingObjectEventArgs.
        /// </summary>
        /// <param name="distance">Distance of flight</param>
        /// <param name="time">Time of flight</param>
        /// <param name="speed">speed of flight</param>
        /// <param name="startPoint"></param>
        /// <param name="finishPoint"></param>
        public FlyingObjectEventArgs(double distance, double time, double speed, Point startPoint, Point finishPoint)
        {
            Distance = distance;
            Time = time;
            Speed = speed;
            StartPoint = startPoint;
            FinishPoint = finishPoint;
        }
    }
}
