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
                Point one = new Point(5, 5);
                Point two = new Point(5, 10);
                Point three = new Point(10, 5);
                Triangle triangle = new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(one, two, three);

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
