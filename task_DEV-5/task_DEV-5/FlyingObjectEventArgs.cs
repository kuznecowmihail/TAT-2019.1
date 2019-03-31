using System;

namespace task_DEV_5
{
    /// <summary>
    /// Class for an event that has some information.
    /// </summary>
    public class FlyingObjectEventArgs : EventArgs
    {
        public Point StartPoint { get; }
        public Point FinishPoint { get; }
        public double Distance { get; }
        public double Time { get; }
        public double Speed { get; }
        public string Message { get; }
        readonly IFlyable obj;

        /// <summary>
        /// Constructor of FlyingObjectEventArgs.
        /// </summary>
        /// <param name="obj">Reference of flying object</param>
        /// <param name="startPoint"></param>
        public FlyingObjectEventArgs(IFlyable obj, Point startPoint)
        {
            this.obj = obj;
            StartPoint = startPoint;
        }

        /// <summary>
        /// Constructor of FlyingObjectEventArgs.
        /// </summary>
        /// <param name="distance">Distance of flight</param>
        /// <param name="time">Time of flight</param>
        /// <param name="speed">speed of flight</param>
        /// <param name="startPoint"></param>
        /// <param name="finishPoint"></param>
        public FlyingObjectEventArgs(Point startPoint, Point finishPoint, double distance, double time, double speed)
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
            Distance = distance;
            Time = time;
            Speed = speed;
            Message = string.Empty;
        }
    }
}
