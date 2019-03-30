using System;

namespace task_DEV_5
{
    /// <summary>
    /// The main class create something flying object for flight to a point. 
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns 0>Normal start of program</returns>
        /// <returns 1>Program have errors</returns>
        static int Main(string[] args)
        {
            try
            {
                IFlyable[] flyingObjects = new IFlyable[] { new Bird(), new Plane(), new SpaceShip() };
                foreach (var i in flyingObjects)
                {
                    // Add subscribes.
                    i.ObjectFliesToPoint += DisplayInformationAbotFlight;
                    i.FlyTo(new Point(100, 200, 800));
                }
                flyingObjects[1].FlyTo(new Point(50, 1500, 300));
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return 1;
            }
        }

        /// <summary>
        /// Method displays information of flight.
        /// </summary>
        /// <param name="obj">Flying object</param>
        /// <param name="e">Object contains information of flight</param>
        public static void DisplayInformationAbotFlight(IFlyable obj, FlyingObjectEventArgs e)
        {
            switch (obj.GetType().Name)
            {
                case "Plane":
                    Console.WriteLine($"{obj.GetType().Name}№{obj.GetHashCode()}:\nFlew {e.Distance}km in {e.Time}hours (final speed is {e.Speed}km/h).\n({e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z}) -> ({e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z})\n");
                    return;
                case "SpaceShip":
                    Console.WriteLine($"{obj.GetType().Name}№{obj.GetHashCode()}:\nFlew {e.Distance}km in {e.Time * 3600}seconds (speed is {e.Speed}km/h).\n({e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z}) -> ({e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z})\n");
                    return;
                default:
                    Console.WriteLine($"{obj.GetType().Name}№{obj.GetHashCode()}:\nFlew {e.Distance}km in {e.Time}hours (speed is {e.Speed}km/h).\n({e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z}) -> ({e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z})\n");
                    return;
            }
        }
    }
}