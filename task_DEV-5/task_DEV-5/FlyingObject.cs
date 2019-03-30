namespace task_DEV_5
{
    /// <summary>
    /// Base abstract class of flying objects.
    /// </summary>
    public abstract class FlyingObject
    {
        protected Point StartPoint { get; set; }
        protected Point FinishPoint { get; set; }
        protected double Speed { get; set; }

        /// <summary>
        /// Constuctor of FlyingObject.
        /// </summary>
        public FlyingObject()
        {
            StartPoint = new Point();
            FinishPoint = new Point();
        } 
    }
}
