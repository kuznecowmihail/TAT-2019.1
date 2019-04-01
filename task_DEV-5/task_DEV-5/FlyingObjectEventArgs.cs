using System;

namespace task_DEV_5
{
    /// <summary>
    /// Class for an event that has some information.
    /// </summary>
    public class FlyingObjectEventArgs : EventArgs
    {
        public double Distance { get; }
        public double Time { get; }
        public string Message { get; }

        /// <summary>
        /// Constructor of FlyingObjectEventArgs for ObjectFlyingToPoint event.
        /// </summary>
        /// <param name="distance">Distance of flight</param>
        /// <param name="time">Time of flight</param>
        /// <param name="speed">speed of flight</param>
        /// <param name="startPoint"></param>
        /// <param name="finishPoint"></param>
        public FlyingObjectEventArgs(double distance, double time)
        {
            Distance = distance;
            Time = time;
        }

        /// <summary>
        /// Constructor of FlyingObjectEventArgs for ObjectIsNotFlying event.
        /// </summary>
        /// <param name="obj">Reference of flying object</param>
        /// <param name="startPoint"></param>
        public FlyingObjectEventArgs(string message)
        {
            Message = message;
        }
    }
}
