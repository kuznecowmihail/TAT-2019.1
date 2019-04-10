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
                Logger log = new Logger();
                Point targetPoint = new Point(100, 200, 800);
                IFlyable[] flyingObjects = new FlyingObject[] { new Bird(), new Plane(), new SpaceShip() };

                foreach (var i in flyingObjects)
                {
                    // Add subscribes.
                    i.ObjectIsFlyingToPoint += log.DisplayInformationAbotFlight;
                    i.ObjectIsNotFlying += log.DisplayInformationAboutFailedFlight;
                    i.FlyTo(targetPoint);
                }
                // For check.
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
    }
}