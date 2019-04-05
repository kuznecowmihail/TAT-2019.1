using System;

namespace Task_CLASSWORK_3
{
    /// <summary>
    /// The main class of programm creates triangles by three points.
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
                Triangle[] triangles = new Triangle[]
                {
                    new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(new Point(0, 0), new Point(5, 0), new Point(2.5, 5 * Math.Sqrt(3) / 2)),
                    new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(new Point(5, 5), new Point(5, 10), new Point(10, 5)),
                    new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(new Point(11, 5), new Point(7, 10), new Point(7, 15)),
                    new EquilateralTriangleBuilder(new RightTriangleBuilder(new RegularTriangleBuilder(null))).Build(new Point(5, 5), new Point(5, 10), new Point(5, 15))
                };

                foreach(var i in triangles)
                {
                    if (i == null)
                    {
                        throw new Exception("The points build other figure.");
                    }
                    else
                    {
                        Console.WriteLine($"{i.GetType().Name} square is {i.GetSquare()}");
                    }
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
