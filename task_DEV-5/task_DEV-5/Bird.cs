using System;

namespace task_DEV_5
{
    /// <summary>
    /// Child class is Bird.
    /// </summary>
    public class Bird : FlyingObject
    {
        static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Constuctor of Bird, initializes random speed 1-20 km/h.
        /// </summary>
        public Bird(double speed = 0) : base(speed)
        {
            Speed = 1 + random.NextDouble() * 20.0;
        }
    }
}
