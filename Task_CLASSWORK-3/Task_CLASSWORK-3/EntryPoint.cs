using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// The main class of programm creates triangle with three points.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns 0>Norm start of program</returns>
        /// <returns 1>Error</returns>
        static int Main(string[] args)
        {
            try
            {
                Triangle triangle = 
                    new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(new Point(5, 5), new Point(5, 10), new Point(10, 5));

                if (triangle == null)
                {
                    throw new Exception("The points build other figure.");
                }
                else
                {
                    Console.WriteLine($"{triangle.GetType().Name} square is {triangle.GetSquare()}");
                }

                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return 1;
            }
        }
    }
}
