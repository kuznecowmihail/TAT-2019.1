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
                Point targetPoint = new Point(100, 200, 800);
                IFlyable[] flyingObjects = new FlyingObject[] { new Bird(), new Plane(), new SpaceShip() };
                foreach (var i in flyingObjects)
                {
                    // Add subscribes.
                    i.ObjectIsFlyingToPoint += DisplayInformationAbotFlight;
                    i.ObjectIsNotFlying += DisplayInformationAboutFailedFlight;
                    i.FlyTo(targetPoint);
                }
                flyingObjects[0].FlyTo(targetPoint);
                flyingObjects[1].FlyTo(new Point(50, 1500, 300));
                flyingObjects[2].FlyTo(new Point(6000, 150000, 80000));
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
        public static void DisplayInformationAbotFlight(Object obj, FlyingObjectEventArgs e)
        {
            // Use hashcode for number is flying object. For clarity.
            Console.WriteLine($"{obj.GetType().Name}№{obj.GetHashCode()}:");
            Console.WriteLine(obj is Plane ? $"Final speed is {e.Speed}km/h (Average speed is {e.Distance / e.Time})." : $"Speed is {e.Speed}km/h.");
            Console.WriteLine($"({e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z}) -> ({e.FinishPoint.X}:{e.FinishPoint.Y}:{e.FinishPoint.Z})\n");
        }

        /// <summary>
        /// Method displays information about flight, if two point is same.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void DisplayInformationAboutFailedFlight(Object obj, FlyingObjectEventArgs e)
        {
            Console.WriteLine($"{obj.GetType().Name}№{obj.GetHashCode()} is already at the finish point ({e.StartPoint.X}:{e.StartPoint.Y}:{e.StartPoint.Z}).\n");
        }
    }
}