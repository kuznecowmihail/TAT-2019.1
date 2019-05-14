using System;

namespace Task7
{

    /// <summary>
    /// The main class of program.
    /// </summary>
    class EntyPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>0 - normal finish of program</returns>
        /// <returns>1 - error</returns>
        static int Main(string[] args)
        {
            try
            {
                string way = "ftp://ftp.pagat.com/adjogos/";
                var handler = new HandlerWebFiles(way);
                handler.WriteNameToList();
                handler.DisplayFileNames();
                handler.DeleteFiles();
                Console.WriteLine("Start parallel download");
                handler.DownloadParallelAllFiles();
                Console.WriteLine($"Parallel download lasted {handler.ParallelDownloadTime.Hours:00}:{handler.ParallelDownloadTime.Minutes:00}:{handler.ParallelDownloadTime.Seconds:00}.{handler.ParallelDownloadTime.Milliseconds}");
                handler.DeleteFiles();
                Console.WriteLine("Start order download");
                handler.DownloadInOrderAllFiles();
                Console.WriteLine($"Download in order lasted {handler.InOrderDownloadTime.Hours:00}:{handler.InOrderDownloadTime.Minutes:00}:{handler.InOrderDownloadTime.Seconds:00}.{handler.InOrderDownloadTime.Milliseconds}");
                handler.CompareMethod();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return 1;
            }
        }
    }
}
