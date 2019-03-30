using System;

namespace task_DEV_5
{
    /// <summary>
    /// The main class create something flying object to flyfor flight to a point. 
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                IFlyable[] flyingObjects = new IFlyable[] { new Bird(), new Plane(), new SpaceShip() };
                foreach (var i in flyingObjects)
                {
                    i.ObjectFliesToPoint += Show_Message;
                    i.FlyTo(new Point(100, 200, 800));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }

        /// <summary>
        /// Method displays information of flight.
        /// </summary>
        /// <param name="obj">Flying object</param>
        /// <param name="e">Object contains information of flight</param>
        public static void Show_Message(IFlyable obj, FlyingObjectEventArgs e)
        {
            switch(obj.GetType().Name)
            {
                case "Bird":
                    Console.WriteLine($"{obj.GetType().Name} flew {e.Distance} km in {e.Time} hours at a speed of {e.Speed} km/h from {e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z} to {e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z}.");
                    return;
                case "Plane":
                    Console.WriteLine($"{obj.GetType().Name} flew {e.Distance} km in {e.Time} hours at a final speed of {e.Speed} km/h from {e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z} to {e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z}.");
                    return;
                case "SpaceShip":
                    Console.WriteLine($"{obj.GetType().Name} flew {e.Distance} km in {e.Time * 3600} seconds at a speed of {e.Speed} km/h from {e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z} to {e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z}.");
                    return;
                default:
                    Console.WriteLine("Unknown flight.");
                    return;
            }
        }
    }
}