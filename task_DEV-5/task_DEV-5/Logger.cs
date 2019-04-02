using System;

namespace task_DEV_5
{
    /// <summary>
    /// Class displays information.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Method displays information of flight.
        /// </summary>
        /// <param name="obj">Flying object</param>
        /// <param name="e">Object contains information of flight</param>
        public void DisplayInformationAbotFlight(Object obj, FlyingObjectEventArgs e)
        {
            if (obj is FlyingObject flyingObject)
            {
                // Use hashcode for number is flying object. For clarity.
                Console.WriteLine($"{flyingObject.GetType().Name}№{flyingObject.GetHashCode()}:");
                Console.WriteLine(obj is Plane ? $"Final speed is {flyingObject.Speed}km/h (Average speed is {e.Distance / e.Time})." : $"Speed is {flyingObject.Speed}km/h.");
                Console.WriteLine($"({flyingObject.StartPoint.X}:{flyingObject.StartPoint.Y}:{flyingObject.StartPoint.Z}) -> ({flyingObject.FinishPoint.X}:{flyingObject.FinishPoint.Y}:{flyingObject.FinishPoint.Z})\n");
            }
        }

        /// <summary>
        /// Method displays information about flight, if two point is same.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void DisplayInformationAboutFailedFlight(Object obj, FlyingObjectEventArgs e)
        {
            if (obj is FlyingObject flyingObject)
            {
                Console.WriteLine($"{flyingObject.GetType().Name}№{flyingObject.GetHashCode()} {e.Message} ({flyingObject.StartPoint.X}:{flyingObject.StartPoint.Y}:{flyingObject.StartPoint.Z}).\n");
            }
        }
    }
}
