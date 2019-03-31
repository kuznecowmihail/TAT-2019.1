using System;

namespace task_DEV_5
{
    /// <summary>
    /// Interface for flying object.
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Event notifies subscribers that an object flies to point.
        /// </summary>
        event EventHandler<FlyingObjectEventArgs> ObjectIsFlyingToPoint;
        event EventHandler<FlyingObjectEventArgs> ObjectIsNotFlying;
        
        /// <summary>
        /// Method of flight to newPoint.
        /// </summary>
        /// <param name="newPoint"></param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// Method returns a reference of this object.
        /// </summary>
        /// <returns>Reference of this object</returns>
        IFlyable WhoAmI();

        /// <summary>
        /// Method calculates time of flight.
        /// </summary>
        /// <returns>Time of flight</returns>
        double GetFlyTime();
    }
}
