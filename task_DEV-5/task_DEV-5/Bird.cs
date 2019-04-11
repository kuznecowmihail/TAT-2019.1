using System;

namespace task_DEV_5
{
    /// <summary>
    /// Child class is Bird.
    /// </summary>
    public class Bird : FlyingObject
    {
        const double MinSpeed = 1;
        const double MaxSpeed = 19;
        /// <summary>
        /// Constuctor of Bird, initializes random speed 1-20 km/h.
        /// </summary>
        public Bird() : base(MinSpeed + (new Random(DateTime.Now.Millisecond)).NextDouble() * MaxSpeed) { }
    }
}
