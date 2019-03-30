using System;

namespace task_DEV_5
{
    /// <summary>
    /// Child class is Bird.
    /// </summary>
    public class Bird : FlyingObject
    {
        /// <summary>
        /// Constuctor of Bird, initializes random speed 1-20 km/h.
        /// </summary>
        public Bird() : base(1.0 + (new Random(DateTime.Now.Millisecond)).NextDouble() * 19.0) { }
    }
}
