using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Task7
{
    /// <summary>
    /// Class handle web files.
    /// </summary>
    class HandlerWebFiles
    {
        string WayToDerictory { get; }
        List<string> FileNames { get; set; }
        public TimeSpan ParallelDownloadTime { get; private set; }
        public TimeSpan InOrderDownloadTime { get; private set; }

        /// <summary>
        /// Constructor of HandlerWebFiles.
        /// </summary>
        /// <param name="way"></param>
        public HandlerWebFiles(string way)
        {
            this.WayToDerictory = way;
            this.FileNames = new List<string>();
        }

        /// <summary>
        /// The method writes names of files to list of string.
        /// </summary>
        public void WriteNameToList()
        {
            FtpWebRequest requestReader = (FtpWebRequest)WebRequest.Create(WayToDerictory);
            requestReader.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse responseReader = (FtpWebResponse)requestReader.GetResponse();
            Stream responseStreamReader = responseReader.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStreamReader);
            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                FileNames.Add(line);
            }
            responseReader.Close();
            streamReader.Close();
            responseStreamReader.Close();
        }

        /// <summary>
        /// The method display names to console.
        /// </summary>
        public void DisplayFileNames()
        {
            foreach (var name in FileNames)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// The method download all files, whose names are contained in the list.
        /// </summary>
        public void DownloadParallelAllFiles()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int N = FileNames.Count;
            Task[] tasks = new Task[N];

            for (int i = 0; i < N; i++)
            {
                tasks[i] = new Task(DownloadFile, FileNames[i]);
            }

            foreach (var task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks);
            stopwatch.Stop();
            ParallelDownloadTime = stopwatch.Elapsed;
        }

        public void DownloadInOrderAllFiles()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var fileName in FileNames)
            {
                DownloadFile(fileName);
            }
            stopwatch.Stop();
            InOrderDownloadTime = stopwatch.Elapsed;
        }

        /// <summary>
        /// The method download file whose names are contained in the list.
        /// </summary>
        /// <param name="name">name of file</param>
        public void DownloadFile(object name)
        {
            FtpWebRequest requestDownload = (FtpWebRequest)WebRequest.Create(WayToDerictory + name);
            requestDownload.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse responseDownload = (FtpWebResponse)requestDownload.GetResponse();
            Stream responseStreamDownload = responseDownload.GetResponseStream();
            FileStream fileStream = new FileStream((string)name, FileMode.Create);
            byte[] buffer = new byte[64];
            int size;

            while ((size = responseStreamDownload.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, size);
            }
            Console.WriteLine($"File {name} downloaded");
            responseDownload.Close();
            responseStreamDownload.Close();
            fileStream.Close();
        }

        /// <summary>
        /// The method deletes files with name 
        /// </summary>
        public void DeleteFiles()
        {
            foreach (var fileName in FileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    Console.WriteLine($"File {fileName} deleted");
                }
            }
        }

        /// <summary>
        /// The method compares two methods for time optimization. 
        /// </summary>
        public void CompareMethod()
        {
            if (InOrderDownloadTime < ParallelDownloadTime)
            {
                Console.WriteLine("In order download method work faster than parallel download method.");
            }
            else
            {
                Console.WriteLine("Parallel download method work faster than in order download method.");
            }
        }
    }
}
